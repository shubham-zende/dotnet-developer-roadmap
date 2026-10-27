using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Practice
{
    internal class Polymorphism
    {
        // Polymorphism:
        // The ability of an object to take on many forms is called polymorphism. 
        //poly - means many
        // morphism - means forms
        // In C#, polymorphism is mainly divided into two types:
        // 1. Compile-time polymorphism (also known as static polymorphism/ Method Overloading)
        // 2. Run-time polymorphism (also known as dynamic polymorphism/ Method Overriding)

        // 1) Compile-time polymorphism (Method Overloading/ Static Polymorphism):
        // - If method action already decided then that polymorphism is called compile-time/Static polymorphism.
        // - Method overloading is an example of compile-time polymorphism.
        // - In method overloading, multiple methods can have the same name but different parameters (different type or number of parameters).
        
        public void Display(int a)
        {
            Console.WriteLine("Calling int Parameter: " + a);
        }
        public void Display(char c)
        {
            Console.WriteLine("Calling char Parameter: " + c);
        }
        public void Display(int a, char b)
        {
            Console.WriteLine("Calling int char Parameter: " + a + " "+ b);
        }
        public void Display(char b, int a)
        {
            Console.WriteLine("Calling char int Parameter: " + b + " " + a);
        }

    }

    // 2) Run-time polymorphism (Method Overriding/ Dynamic Polymorphism):
    // - If method action is decided at run time then that polymorphism is called run-time/dynamic polymorphism.
    // - Method overriding is an example of run-time polymorphism.
    // - In method overriding, a derived class provides a specific implementation of a method that is already defined in its base class.
    // - The method in the base class must be marked with the 'virtual' keyword, and the method in the derived class must be marked with the 'override' keyword.
    // - This allows the derived class to provide its own implementation of the method, which will be called at runtime based on the actual object type.

    // Abstract class:
    // - An abstract class is a class that cannot be instantiated and is typically used as a base class for other classes.
    // - It can contain abstract methods (methods without implementation) that must be implemented by derived classes.
    // - Abstract classes can also contain concrete methods (methods with implementation) that can be inherited by derived classes.
    // - Abstract classes are declared using the 'abstract' keyword.
    
    public abstract class Account
    {
        public abstract void AccDetails();
        public abstract void Deposite();
        public abstract void Withdrowal();
        public abstract void Balance();
        public void BankDetails()
        {
            Console.WriteLine("Calling Bank Details function.");
        }
    }
    class SavingAccount : Account
    {
        public override void AccDetails()
        {
            Console.WriteLine("Calling Saving Account Details function.");
        }
        public override void Deposite()
        {
            Console.WriteLine("Calling Saving Account Deposite function.");
        }
        public override void Withdrowal()
        {
            Console.WriteLine("Calling Saving Account Withdrowal function.");
        }
        public override void Balance()
        {
            Console.WriteLine("Calling Saving Account Balance function.");
        }
    }
}
