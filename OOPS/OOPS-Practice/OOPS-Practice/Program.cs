using System;

namespace OOPS_Practice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Polymorphism
            //Program person = new Program();
            //Polymorphism p = new Polymorphism();
            //p.Display(10);
            //p.Display('A', 12);

            //Account s = new SavingAccount(); // It is the main concept of polymorphism only this line.
            //s.AccDetails();
            //s.BankDetails();
            //s.Deposite();
            //s.Withdrowal();
            //s.Balance(); 


            Parent p1 = new Child();  // It is the main concept of polymorphism only this line.
            p1.Display();

            //Inheritance

            // Single Inheritance
            //Test t = new Test();
            //t.GetStudentInfo();
            //t.GetMarks();
            //t.DisplayStudentInfo();
            //t.DisplayMarks();

            // Multilevel Inheritance
            //Result r = new Result();
            //r.GetStudentInfo();
            //r.GetMarks();
            //r.DisplayStudentInfo();
            //r.DisplayMarks();
            //r.GetResult();

            //Hybrid Inheritance
            //Teacher teacher = new Teacher();
            //teacher.TeacherDetails();
            //teacher.Subjects();

            //Student1 st = new Student1();
            //st.StudentDetails();
            //st.Subjects();

            // hierarchical Inheritance
            //Ride r = new Ride();
            //r.GetCustomerDetails();
            //r.GetRideDetails();
            //r.GetRideLocations();
            //r.ShowCustomerDetails();
            //r.ShowRideDetails();
            //r.ShowRideLocations();

            //Driver dr = new Driver();
            //dr.GetDriverDetails();
            //dr.ShowDriverDetails();

            // Multiple Inheritance
            //IAnimal i1 = new Dog();
            //i1.Eat();
            //i1.Sleep();

            //IMammal i2 = new Dog();
            //i2.Walk();
            //i2.Run();

            // Encapsulation
            //Encapsulation en = new Encapsulation();
            //en.Balance = 5000;
            //Console.WriteLine("Balance: " + en.Balance);
            //en.Balance = -2000;
            //Console.WriteLine("Balance: " + en.Balance);

            //// Abstraction
            //Animal an = new Cat();
            //an.Sound();
            Console.ReadLine();


        }
    }
}