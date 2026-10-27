using System;

namespace OOPS_Practice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Program person = new Program();
            Polymorphism p = new Polymorphism();
            //p.Display(10);
            //p.Display('A', 12);

            Account s = new SavingAccount();
            s.AccDetails();
            s.BankDetails();
            s.Deposite();
            s.Withdrowal();
            s.Balance();
            Console.ReadLine();


        }
    }
}