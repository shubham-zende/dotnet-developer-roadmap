using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Practice
{
    abstract class Animal
    {
        // Abstraction:
        // - Abstraction is the process of hiding the implementation details and showing only the functionality to the user.
        // - It allows the user to interact with an object without needing to understand the complex underlying code.
        // - In C#, abstraction is achieved using abstract classes and interfaces.

        public abstract void Sound();
    }
    class Cat : Animal
    {
        public override void Sound()
        {
            Console.WriteLine("Cat chirp");
        }
    }
}
