using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Practice
{
    internal class Student
    {
        // Inheritance:
        // - Inheritance is a fundamental concept in object-oriented programming (OOP) that allows a class to inherit properties and behaviors (methods) from another class.
        // - The class that is inherited from is called the base class (or parent class), and the class that inherits is called the derived class (or child class).
        // - Inheritance promotes code reusability and establishes a hierarchical relationship between classes.
        // - In C#, inheritance is implemented using the ':' symbol.
        // - Types of Inheritance in C#:
        // 1. Single Inheritance: A derived class inherits from a single base class.
        // 2. Multilevel Inheritance: A derived class inherits from a base class, and another class inherits from the derived class.
        // 3. Hierarchical Inheritance: Multiple derived classes inherit from a single base class.
        // 4. Multiple Inheritance (through interfaces): C# does not support multiple inheritance for classes, but a class can implement multiple interfaces.
        // 5. Hybrid Inheritance: A combination of two or more types of inheritance.

        // 1. Single Inheritance Example:

        int StudentId;
        string StudentName;

        public void GetStudentInfo()
        {
            Console.WriteLine("Enter student id: ");
            StudentId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter student name : ");
            StudentName = Console.ReadLine();
        }
        public void DisplayStudentInfo()
        {
            Console.WriteLine("Student Id: " + StudentId);
            Console.WriteLine("Student Name: " + StudentName);
        }
    }
    class Test : Student
    {
        public int mark1, mark2;
        public void GetMarks()
        {
            Console.WriteLine("Enter mark1: ");
            mark1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter mark2: ");
            mark2 = Convert.ToInt32(Console.ReadLine());
        }
        public void DisplayMarks()
        {
            Console.WriteLine("Mark1: " + mark1);
            Console.WriteLine("Mark2: " + mark2);
        }
    }
    class Result : Test
    {
        // 2. Multilevel Inheritance Example:
        int result;
        public void GetResult()
        {
            result = mark1 + mark2;
            Console.WriteLine("Result: " + result);
        }
    }

    // 3. Hierarchical Inheritance Example:
    class School 
    {
        public void Subjects()
        {
            Console.WriteLine("Subjects: Math, Science, English");
        }
    }
    class Teacher : School
    {
        public void TeacherDetails()
        {
            Console.WriteLine("I am a teacher & my name is John Doe.");
        }
    }
    class Student1 : School
    {
        public void StudentDetails()
        {
            Console.WriteLine("I am a student & my name is Satish.");
        }
    }

    // 4.Hybrid Inheritance Example:
    class Uber
    {
        public string RideName;
        public void GetRideDetails()
        {
            Console.WriteLine("Please confime the your ride bike/auto/car : ");
            RideName = Console.ReadLine();
        }
        public void ShowRideDetails()
        {
            Console.WriteLine("Your ride is : " + RideName);
        }
    }
    class Customer : Uber
    {
        public string CustomerName;
        public string CustomerMobile;
        public void GetCustomerDetails()
        {
            Console.WriteLine("Please enter your name : ");
            CustomerName = Console.ReadLine();
            Console.WriteLine("Please enter your mobile number : ");
            CustomerMobile = Console.ReadLine();
        }
        public void ShowCustomerDetails()
        {
            Console.WriteLine("Your name is : " + CustomerName);
            Console.WriteLine("Your mobile number is : " + CustomerMobile);
        }
    }
    class Driver : Uber
    {
        public string DriverName;
        public string DriverMobile;
        public string VehicleNumber;
        public void GetDriverDetails()
        {
            Console.WriteLine("Please enter your name : ");
            DriverName = Console.ReadLine();
            Console.WriteLine("Please enter your mobile number : ");
            DriverMobile = Console.ReadLine();
            Console.WriteLine("Please enter your vehicle number : ");
            VehicleNumber = Console.ReadLine();
        }
        public void ShowDriverDetails()
        {
            Console.WriteLine("Your name is : " + DriverName);
            Console.WriteLine("Your mobile number is : " + DriverMobile);
            Console.WriteLine("Your vehicle number is : " + VehicleNumber);
        }
    }
    class Ride : Customer
    {
        public string pickupLocation, dropLocation;
        public void GetRideLocations()
        {
            Console.WriteLine("Please enter your pickup location : ");
            pickupLocation = Console.ReadLine();
            Console.WriteLine("Please enter your drop location : ");
            dropLocation = Console.ReadLine();
        }
        public void ShowRideLocations()
        {
            Console.WriteLine("Your pickup location is : " + pickupLocation);
            Console.WriteLine("Your drop location is : " + dropLocation);
        }
    }

    // 5. Multiple Inheritance Example (through interfaces):
    interface IAnimal
    {
        void Eat();
        void Sleep();
    }
    interface IMammal
    {
        void Walk();
        void Run();
    }
    class Dog : IAnimal, IMammal
    {
        public void Eat()
        {
            Console.WriteLine("Dog is eating.");
        }
        public void Sleep()
        {
            Console.WriteLine("Dog is sleeping.");
        }
        public void Walk()
        {
            Console.WriteLine("Dog is walking.");
        }
        public void Run()
        {
            Console.WriteLine("Dog is running.");
        }
    }
}
