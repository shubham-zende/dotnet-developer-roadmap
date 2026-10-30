
using System.Threading;

namespace Threading_Practice
{
    internal class Program
    {
        // Threading:
        // Threading is a technique that allows multiple threads to run concurrently within a single process. Each thread can execute independently, allowing for better utilization of CPU resources and improved application responsiveness.
        // In C#, the System.Threading namespace provides classes and methods for working with threads. The Thread class represents a thread of execution, and you can create and manage threads using this class.

        // It is the smallest executable unit, CPU allocate some memory as well as time.
        // It is mainly used for parallel Processing.

        // Thread - Class is used to create threads in C#.
        // Start() - Method is used to start the thread.
        // Sleep() - Method is used to pause the thread for a specified amount of time.
        // Abort() - Method is used to terminate the thread.
        // Join() - Method is used to wait for a thread to complete its execution.
        // IsAlive - Property is used to check if a thread is still running.
        // ThreadPool - Class is used to manage a pool of threads that can be reused for executing tasks.
        // ThreadLocal<T> - Class is used to create thread-local storage, allowing each thread to have its own instance of a variable.
        // ThreadStatic - Attribute is used to indicate that a static field should be unique to each thread.
        // ThreadPriority - Enum is used to specify the priority of a thread, which can affect its scheduling and execution order.

        // Types of Threading:
        // 1. Single Threading
        // 2. Multi Threading

        // 1. Single Threading:
        // In single threading, a program executes one thread at a time. The execution of tasks is sequential, and the program waits for each task to complete before moving on to the next one. This can lead to inefficiencies, especially when tasks involve waiting for I/O operations or other time-consuming processes.


        public static void Thread1()
        {
            int i;
            for (i = 0; i <= 5; i++)
            {
                Console.WriteLine("Calling my thread");
                Thread.Sleep(1000);
            }
        }

        // 2. Multi Threading:
        // In multi-threading, a program can execute multiple threads concurrently. Each thread can run independently, allowing for better utilization of CPU resources and improved application responsiveness. Multi-threading is particularly useful for tasks that can be performed in parallel, such as handling multiple user requests in a web server or performing background processing while keeping the user interface responsive.

        public static void Thread2()
        {
            Console.WriteLine("Calling My Thread 2");
        }
        public static void Thread3()
        {
            Console.WriteLine("Calling My Thread 3");
        }

        static int cnt = 0;
        static void Increment()
        {
            for(int i = 0; i < 100_000; i++)
            {
                Interlocked.Increment(ref cnt);
            }
        }
        public static void Main(string[] args)
        {
            // Single Threading Example:   
            //Thread t1 = new Thread(Thread1);
            //t1.Start();
            //t1.Abort();

            // Multi Threading Example:
            //Thread t1 = new Thread(Thread1);
            //Thread t2 = new Thread(Thread2);
            //Thread t3 = new Thread(Thread3);
            //t1.Start();
            //t2.Start();
            //t3.Start();

            // Race Condition Example:
            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Increment);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.WriteLine("Count: 200000(Expected)");
            Console.WriteLine("Count: " + cnt);
            Console.ReadLine();
        }
    }
}