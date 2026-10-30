# Threading in C# — Single Threading, Multithreading, Lifecycle, and Common Problems

> **Level:** Beginner  
> **Language:** C#  
> **Namespace:** `System.Threading`  
>
> Threading lets a program execute work using one or more threads. The examples below are small console-app examples. Run each example separately unless stated otherwise.

## 1. What is a thread?

A **thread** is an execution path inside a process. A process can contain one or more threads. Threads in the same process share memory, so they can communicate efficiently—but shared data must be handled carefully.

- **Single-threaded execution:** one thread performs the work. Tasks generally run one after another.
- **Multithreaded execution:** multiple threads can make progress independently. On a multi-core CPU, they may run in parallel; on a single core, the operating system may switch between them.

### Single-threading example

```csharp
using System;

class Program
{
    static void DoWork(string name)
    {
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"{name}: {i}");
            Thread.Sleep(500); // Simulates work; blocks this thread
        }
    }

    static void Main()
    {
        DoWork("First");
        DoWork("Second");

        Console.WriteLine("Finished");
    }
}
```

**What happens?** `First` completes all three iterations before `Second` starts. Only the main thread is doing this work.

### Multithreading example with `Thread`

```csharp
using System;
using System.Threading;

class Program
{
    static void DoWork(object? value)
    {
        string name = (string)value!;

        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"{name}: {i} (Thread {Thread.CurrentThread.ManagedThreadId})");
            Thread.Sleep(500);
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(DoWork);
        Thread t2 = new Thread(DoWork);

        t1.Start("First");
        t2.Start("Second");

        t1.Join();
        t2.Join();

        Console.WriteLine("Both threads finished");
    }
}
```

**What happens?** Both threads are started. Their output may interleave and the order is not guaranteed. `Join()` makes the main thread wait until each worker thread finishes.

> `Thread.Sleep` is used here only to make the scheduling easier to observe. It is not a recommended way to coordinate threads in real applications.

## 2. Thread lifecycle

A thread commonly moves through these states:

1. **Unstarted:** a `Thread` object has been created, but `Start()` has not been called.
2. **Runnable / Ready:** `Start()` has been called and the thread is eligible to run.
3. **Running:** the scheduler is currently executing the thread.
4. **Wait / Sleep / Join:** the thread is temporarily not eligible to run because it is sleeping, waiting for a lock, or waiting for another thread.
5. **Stopped:** the thread's method has returned or an unhandled exception has ended it.

The .NET `ThreadState` enum is a set of flags and can show combined states. Avoid relying on it for application logic.

### Lifecycle example

```csharp
using System;
using System.Threading;

class Program
{
    static void Work()
    {
        Console.WriteLine("Worker: running");
        Thread.Sleep(1000); // Temporarily enters a wait/sleep state
        Console.WriteLine("Worker: finishing");
    }

    static void Main()
    {
        Thread worker = new Thread(Work);

        Console.WriteLine($"Before Start: {worker.ThreadState}"); // Unstarted

        worker.Start();
        Console.WriteLine($"After Start: {worker.ThreadState}");  // Usually Running or another transient state

        worker.Join(); // Main waits for worker
        Console.WriteLine($"After Join: {worker.ThreadState}");   // Stopped
    }
}
```

The exact state printed immediately after `Start()` is timing-dependent.

## 3. Threading limitations and common problems

### 3.1 Race condition

A **race condition** occurs when the result depends on the timing or interleaving of multiple threads accessing shared data.

In this example, `count++` is not one indivisible operation. It involves reading, adding, and writing.

```csharp
using System;
using System.Threading;

class Program
{
    static int count = 0;

    static void Increment()
    {
        for (int i = 0; i < 100_000; i++)
        {
            count++; // Not thread-safe
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Expected: 200000");
        Console.WriteLine($"Actual:   {count}"); // May be less than expected
    }
}
```

**Fix using `Interlocked`:**

```csharp
using System;
using System.Threading;

class Program
{
    static int count = 0;

    static void Increment()
    {
        for (int i = 0; i < 100_000; i++)
        {
            Interlocked.Increment(ref count);
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine(count); // 200000
    }
}
```

`Interlocked.Increment` performs the increment atomically for this integer operation.

### 3.2 Lock / mutual exclusion

A **lock** protects a critical section so only one thread at a time can execute that section for the same lock object.

```csharp
using System;
using System.Threading;

class Program
{
    private static readonly object gate = new object();
    private static int count = 0;

    static void Increment()
    {
        for (int i = 0; i < 100_000; i++)
        {
            lock (gate)
            {
                count++;
            }
        }
    }

    static void Main()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine(count); // 200000
    }
}
```

**Important:** Every thread that accesses the protected data must use the same lock object. Keep the locked section small, and do not `await` inside a `lock` block.

### 3.3 Lock starvation

**Starvation** happens when a thread repeatedly fails to get the CPU time or resource it needs because other threads keep getting access first. A thread waiting for a lock for a very long time can experience starvation.

The following is an illustrative example of lock contention; it does **not** guarantee starvation because thread scheduling and lock acquisition order are not guaranteed.

```csharp
using System;
using System.Threading;

class Program
{
    private static readonly object gate = new object();

    static void FrequentWorker()
    {
        for (int i = 0; i < 20; i++)
        {
            lock (gate)
            {
                Thread.Sleep(50); // Holds the lock for a while
            }
        }
    }

    static void WaitingWorker()
    {
        Console.WriteLine("Waiting worker wants the lock...");

        lock (gate)
        {
            Console.WriteLine("Waiting worker acquired the lock");
        }
    }

    static void Main()
    {
        Thread frequent = new Thread(FrequentWorker);
        Thread waiting = new Thread(WaitingWorker);

        frequent.Start();
        Thread.Sleep(10);
        waiting.Start();

        frequent.Join();
        waiting.Join();
    }
}
```

**How to reduce starvation risk:**
- Keep lock durations short.
- Avoid unnecessary work while holding a lock.
- Avoid repeatedly releasing and immediately reacquiring a lock in a tight loop.
- Consider higher-level synchronization primitives when they better fit the problem.
- Do not assume `lock` guarantees a particular fairness order.

### 3.4 Deadlock

A **deadlock** occurs when two or more threads wait forever for resources held by each other.

Example: Thread 1 owns `lockA` and waits for `lockB`, while Thread 2 owns `lockB` and waits for `lockA`.

```csharp
using System;
using System.Threading;

class Program
{
    private static readonly object lockA = new object();
    private static readonly object lockB = new object();

    static void Main()
    {
        Thread t1 = new Thread(() =>
        {
            lock (lockA)
            {
                Thread.Sleep(100);
                lock (lockB)
                {
                    Console.WriteLine("Thread 1 acquired both locks");
                }
            }
        });

        Thread t2 = new Thread(() =>
        {
            lock (lockB)
            {
                Thread.Sleep(100);
                lock (lockA)
                {
                    Console.WriteLine("Thread 2 acquired both locks");
                }
            }
        });

        t1.Start();
        t2.Start();

        // This example can deadlock. Do not use it in a production program.
        // Join may never return if the deadlock occurs.
    }
}
```

**How to prevent deadlocks:**
- Acquire multiple locks in a consistent global order in every thread.
- Avoid nested locks where possible.
- Keep critical sections short.
- Avoid calling unknown or external code while holding a lock.
- For more complex scenarios, consider `Monitor.TryEnter` with a timeout or redesigning the shared-resource access.

### 3.5 Thread priority

A thread's **priority** is a scheduling hint to the operating system. Higher priority does not guarantee that a thread runs first or finishes first. Actual scheduling depends on the OS, workload, and runtime.

```csharp
using System;
using System.Threading;

class Program
{
    static void Work()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(
                $"{Thread.CurrentThread.Name}: {i}, Priority: {Thread.CurrentThread.Priority}");
        }
    }

    static void Main()
    {
        Thread low = new Thread(Work)
        {
            Name = "Low",
            Priority = ThreadPriority.Lowest
        };

        Thread high = new Thread(Work)
        {
            Name = "High",
            Priority = ThreadPriority.Highest
        };

        low.Start();
        high.Start();

        low.Join();
        high.Join();
    }
}
```

Available values include `Lowest`, `BelowNormal`, `Normal`, `AboveNormal`, and `Highest`.

**Note:** Do not use priority to coordinate work or guarantee execution order. The default `Normal` priority is usually appropriate.

## 4. `Thread` vs `Task`

For modern C# application code, prefer the Task-based Asynchronous Pattern (`Task` / `Task<T>`) for most concurrent and asynchronous work.

- `Thread` represents an actual operating-system thread.
- `Task` represents an operation that may complete in the future. A task does not necessarily own a dedicated thread.
- `Task.Run` queues CPU-bound work to the thread pool.
- `async` / `await` is especially useful for non-blocking I/O such as HTTP requests, database calls, and file operations.

### Simple Task example

```csharp
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task task1 = Task.Run(() => DoWork("First"));
        Task task2 = Task.Run(() => DoWork("Second"));

        await Task.WhenAll(task1, task2);

        Console.WriteLine("Both tasks finished");
    }

    static void DoWork(string name)
    {
        Console.WriteLine($"{name} is running");
    }
}
```

`Task.WhenAll` completes when all supplied tasks complete. `await` waits asynchronously rather than blocking the current thread.

## 5. Quick comparison

| Concept | Meaning |
|---|---|
| Single-threading | Work executes on one thread |
| Multithreading | Multiple threads make progress independently |
| Race condition | Output depends on timing of shared-data access |
| `lock` | Allows one thread at a time into a protected section |
| Starvation | A thread waits excessively for CPU time or a resource |
| Deadlock | Threads wait on each other indefinitely |
| Thread priority | Scheduling hint; not an execution-order guarantee |
| `Join()` | Waits for a thread to finish |
| `Sleep()` | Pauses the current thread for a period |
| `Interlocked` | Provides atomic operations for supported variables |
| `Task` | Represents an asynchronous/concurrent operation |

## 6. Interview Questions & Short Answers

### 1. What is the difference between a process and a thread?

- **Process:** An independent program in execution with its own memory space.
- **Thread:** A lightweight execution unit within a process that shares the process memory.

### 2. What is the difference between single-threading and multithreading?

- **Single-threading:** Executes one task at a time using a single thread.
- **Multithreading:** Allows multiple threads to execute tasks concurrently within the same process.

### 3. What are the main states in a thread's lifecycle?

The main states are:
- Unstarted
- Runnable (Ready)
- Running
- Waiting / Sleeping / Blocked
- Stopped (Terminated)

### 4. What is a race condition? How can you prevent it?

A race condition occurs when multiple threads access shared data simultaneously, causing unexpected results.

**Prevention:** Use `lock`, `Interlocked`, or other synchronization mechanisms.

### 5. What is the purpose of the `lock` keyword?

The `lock` keyword ensures that only one thread at a time can access a protected code section, preventing simultaneous modifications of shared data.

### 6. What is the difference between deadlock and starvation?

- **Deadlock:** Two or more threads wait for each other indefinitely.
- **Starvation:** A thread continuously waits because other threads keep getting access to the required resource.

### 7. Does a higher thread priority guarantee that a thread runs first?

No. Higher priority is only a scheduling hint. It does not guarantee execution order or completion time.

### 8. What is the difference between `Thread` and `Task`?

- **Thread:** Represents an actual execution thread.
- **Task:** Represents an asynchronous operation that may execute using a thread-pool thread or another execution mechanism.

### 9. What is the purpose of `Join()`?

`Join()` makes the calling thread wait until the specified thread completes execution.

**Example:**

\```csharp
t1.Start();
t1.Join();
\```

### 10. Why is `Interlocked.Increment` safer than `count++` when multiple threads update the same integer?

`count++` is not an atomic operation and can cause race conditions. `Interlocked.Increment()` performs the increment atomically, ensuring thread-safe updates.

**Example:**

\```csharp
Interlocked.Increment(ref count);
\```

---

## 7. Best practices

- Prefer `Task` and `async` / `await` for most modern application code.
- Use `Interlocked` for simple atomic updates and `lock` for protecting multi-step shared state.
- Keep critical sections short.
- Avoid shared mutable state when possible.
- Do not depend on thread execution order or priority.
- Handle exceptions from tasks and threads appropriately.
- Do not use `Thread.Abort`; it is obsolete and unsupported in modern .NET.
- Use cancellation tokens for cooperative cancellation of tasks and operations.

---

**Remember:** Multithreading can improve responsiveness and throughput, but it also introduces coordination problems. Correct synchronization is more important than simply creating more threads.