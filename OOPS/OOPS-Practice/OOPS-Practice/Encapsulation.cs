using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Practice
{
    internal class Encapsulation
    {
        // Encapsulation:
        // - Encapsulation is the process of wrapping data (variables) and methods (functions) into a single unit called a class.
        // - It is one of the fundamental principles of object-oriented programming (OOP).
        // - Encapsulation helps to protect the internal state of an object from unintended interference and misuse.
        // - In C#, encapsulation is achieved using access modifiers (public, private, protected, internal) to control the visibility of class members.

        private double balance;
        public double Balance
        {
            get { return balance; }
            set { 
                if (value >= 0)
                {
                    balance = value;
                }
                else
                {
                    Console.WriteLine("Balance cannot be negative.");
                }
                    
            }
        }
    }
}
