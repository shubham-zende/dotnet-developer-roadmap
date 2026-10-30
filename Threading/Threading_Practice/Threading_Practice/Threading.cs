using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_Practice
{
    internal class Threading
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

        public static void Thread1()
        {
            int i;
            for(i = 0; i <= 5; i++)
            {
                Console.WriteLine("Calling my thread");
                Thread.Sleep(1000);
            }
        }
    }
}
