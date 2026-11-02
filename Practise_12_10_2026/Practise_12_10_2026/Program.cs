using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Practise_12_10_2026
{
    class UDException : ApplicationException
    {
        public string message = "";
        public UDException(string s)
        {
            message = s;
        }
    }
    internal class Program
    {
        // What is Data type:
        // Data type defines the what type of data variable is stored.

        // There are two types of data types:
        // 1) Value Type:
        // 2) Reference Type:

        // 1) Value Type: It stores data directly in memory.
        // e.g. int, float, char, double, bool, stuct, etc.,

        // 2) Reference Type: It stores reference(memory address) of the data.
        // e.g. string, object, arrays, classes, etc.,

        //----------------------------------------------------------------------------


        // Operators:
        // Operators are the symbols that performance specific operations on variables and values.
        // Types of Operators:
        // 1) Arithmatic operators : +, -, /, *, %
        // 2) Assignment operators : +=, -=, /=, */, %=
        // 3) Comparision operators : ==, <, >, <=, >=, != 
        // 4) Logical operators: &&, ||
        // 5) Increment/Decrement operators: ++, --

        void Voter(int age)
        {
            if(age >= 18)
            {
                Console.WriteLine("You are eligeble for voting.");
            }
            else
            {
                Console.WriteLine("You are not eligeble for voting.");
            }
        }

        // Variable:
        // variable is like a container in memory that stores data. It has a name, type and value.

        // Types of variables: 
        // 1) Global variables: Declares outside the function/method and inside a class.
        // 2) Local variables: Declares inside any method/function.
        // 3) Constant variables: Values cannot be change, after declaration. like const pi = 3.142;
        // 4) ReadOnly variables: Value set only at intialization or in constructor.
        //-----------------------------------------------------------------------------------------------

        // Conditional Statements:
        // Conditional statement allows progaram to make decision and execute code depending on the conditions.

        // Types of conditional statements:
        // 1) if:
        // 2) if-else :
        // 3) if - else -if: 
        // 4) Switch: 

        // 1) if: It runs when only condition is true.

        void IfCondition()
        {
            int a = 10, b = 20;
            if(a > b)
            {
                Console.WriteLine($"Value of {a} is greater than {b}");
            }
        }
        // 2) if_else : It provides alternative path when the condition is false.

        // 3) if_else_if: Used when there are multiple conditions.

        // 4) Switch : Used when you compare same variable with multiple values.

        void SwitchStatement()
        {
            int num1, num2, Sum, Sub, Div, Mul;
            Console.WriteLine("Enter the 1st number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the 2nd number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose your operation: " +
                "\n 1. Addition" +
                "\n 2. Subtraction" +
                "\n 3. Multiplication" +
                "\n 4. Division");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    {
                        Sum = num1 + num2;
                        Console.WriteLine($"Addition of {num1} and {num2} = {Sum}");
                        break;
                    }
                case 2:
                    {
                        Sub = num1 - num2;
                        Console.WriteLine($"Subtraction of {num1} and {num2} = {Sub}");
                        break;
                    }
                case 3:
                    {
                        Div = num1 / num2;
                        Console.WriteLine($"Division of {num1} and {num2} = {Div}");
                        break;
                    }
                case 4:
                    {
                        Mul = num1 * num2;
                        Console.WriteLine($"Multiplication of {num1} and {num2} = {Mul}");
                        break;
                    }

                default :
                    {
                        Console.WriteLine("Option are not available.");
                        break;
                    }
            }
        }

        // --------------------------------------------------------------------------------------------

        // Loops:
        // Loops are the block of code that repeat multiple time without writing it again and again.
        // Types of loops:
        // 1) For Loop
        // 2) While loop
        // 3) do_While loop

        // 1) for loop: If we know the no. of repeatation that time we will use the for loop.

        void MultipleOf5()
        {
            int n = 5;
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{n} * {i} = {n * i}");
            }
        }
        void Addition()
        {
            int sum =0;
            for(int i = 1; i <= 10; i++)
            {
                sum += i;
            }
            Console.WriteLine("Sum of First 10 numbers = " + sum);
        }

        // 2) While loop: When we don't know the no.of iterations that time we can use while loop.

        void MultipleOf10()
        {
            int i = 1, num = 10;
            while(i <= 10)
            {
                Console.WriteLine($"{num} * {i} = {num * i}");
                i++;
            }
        }

        // 3) do_while : It runs atleast once even the condition is false.
        void MultipleOf2()
        {
            int a = 2, cnt = 1;
            do
            {
                Console.WriteLine($"{a} * {cnt} = {a * cnt}");
                cnt++;
            } while (cnt >= 10);
        }
        //-----------------------------------------------------------------------------------------
        // examples:

        void Factorial()
        {
            int i, n, fact = 1;
            Console.WriteLine("Enter the number = ");
            n = Convert.ToInt32(Console.ReadLine());
            for(i = 1; i <= n; i++)
            {
                fact *= i;
            }
            Console.WriteLine($"Factorial of {n} = {fact}");
        }

        void Prime()
        {
            int n, cnt = 0;
            Console.WriteLine("Enter the number : ");
            n = Convert.ToInt32(Console.ReadLine());
            for(int i = 2; i <= n/2; i++)
            {
                if( n % i == 0)
                {
                    cnt++;
                    break;
                }
            }
            if(cnt == 0)
            {
                Console.WriteLine("Given number {0} is prime number.", n);
            }
            else
            {
                Console.WriteLine("Given number {0} is not prime number.",n);
            }
        }

        void Fibbonacci1()
        {
            int a = 0, b = 1;
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine(a + " ");
                b = a + b;
                a = b - a;
            }
        }
        void Fibbonacci2()
        {
            int a = 0, b = 1;
            for(; a <= 34;)
            {
                Console.WriteLine(a + " ");
                b = a + b;
                a = b - a;
            }
        }
        void PrintWelcome()
        {
            for(int i = 0; i < 1; Console.WriteLine("Welcome"))
            {
                i++;
            }
        }

        void Pattern1()
        {
            int k = 1;
            for(int i = 1; i <= 3; i++)
            {
                for(int j = 1; j <= 3; j++)
                {
                    Console.Write(k + " ");
                    k++;
                }
                Console.WriteLine();
            }
        }
        void Pattern2()
        {
            for(int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        void Pattern3()
        {
            for(int i = 1; i <= 5; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        void Pattern4()
        {
            for(int i = 5; i >= 1; i--)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        void Pattern5()
        {
            for(int i = 1; i <=5; i++)
            {
                for(int j = 5; j >= i; j--)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        void Pattern6()
        {
            for( int i = 5; i >= 1; i--)
            {
                for(int j = 5; j >= i; j--)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        void Pattern7()
        {
            for(int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        void Pattern8()
        {
            for( int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        void Pattern9()
        {
            for (int i = 1; i <= 5; i++)
            {
                for(int j = 5; j > i; j--)
                {
                    Console.Write(" ");
                }
                for(int k = 1; k <= i; k++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        void CountDigits()
        {
            int n = 100; int count = 0;
            while(n > 0)
            {
                count++;
                n = n / 10;
            }
            Console.WriteLine(count);
        }
        void ReverseNumber()
        {
            int n = 143, sum = 0, rem;
            while(n > 0)
            {
                rem = n % 10;
                sum = rem + (sum * 10);
                n = n / 10;
            }
            Console.WriteLine(sum);
        }
        void Pallindrom()
        {
            int num = 121, rem, sum = 0;
            int m = num;
            while(num > 0)
            {
                rem = num % 10;
                sum = rem + (sum * 10);
                num = num / 10;
            }
            if( sum == m)
            {
                Console.WriteLine($"{m} == {sum}");
            }
            else
            {
                Console.WriteLine($"{m} != {sum}");
            }
        }
        void AmstrongNumber()
        {
            int n = 1634, rem, sum = 0, m, p = 0, k;
            m = n;
            k = n;
            while( n > 0)
            {
                p++;
                n = n / 10;
            }
            while(m > 0)
            {
                rem = m % 10;
                sum = sum + (int)Math.Pow(rem, p);
                m = m / 10;
            }
            if(sum == k)
            {
                Console.WriteLine("Amstrong number.");
            }
            else
            {
                Console.WriteLine("Not an Amstrong number.");
            }
        }
        void findAmstrong()
        {
            int n;
            for(n = 10; n <= 20000; n++)
            {
                int sum = 0, rem, p = 0, m, k;
                m = n;
                k = n;
                while(m > 0)
                {
                    p++;
                    m = m / 10;
                }
                int s = n;
                while(k > 0)
                {
                    rem = k % 10;
                    sum = sum + (int)Math.Pow(rem, p);
                    k = k / 10;
                }
                if(sum == s)
                {
                    Console.WriteLine(s);
                }
            }
        }
        // Arrays;-
        //int[] arr = new int[5];
        //int[] arr = { 1, 2, 4, 5, 6 };
        //int l = arr.Length;
        // arr[1] = 2    -- accessing an array element.

        void ArrayExamples()
        {
            int[] arr = { 10, 20, 30, 40, 50 };
            Console.WriteLine(arr);
            Console.WriteLine(arr[3] + "\n");

            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine("\n");
            for(int j = arr.Length - 1; j >= 0; j--)
            {
                Console.WriteLine(arr[j]);
            }

        }
        void FirstMax()
        {
            int[] arr = { 10, 23, 67, 4, 7, 34, 3 };
            int max = 0;
            for(int i  = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine(max);
        }
        void SecondMax()
        {
            int[] arr = { 10, 34, 234, 435, 743, 3, 43, 2, 1 };
            int max1 = 0, max2 = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max1)
                {
                    max2 = max1;
                    max1 = arr[i];
                }
                if (arr[i] > max2 && arr[i] < max1)
                {
                    max2 = arr[i];
                }
            }
            Console.WriteLine(max1);
            Console.WriteLine(max2);
        }
        void ArraySwap()
        {
            int[] arr = { 23, 4, 2, 5, 23, 55, 63, 0, 612, 3 };
            int temp = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            
            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        void ArrayFromUser()
        {
            int[] a = new int[5];
            int i;
            Console.WriteLine("Enter 5 values into the array.");
            for(i = 0; i < a.Length; i++)
            {
                a[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int j = 0; j < a.Length; j++)
            {
                Console.Write(a[j] + " ");
            }
        }
        void ArrayFromUser2x2()
        {
            int[,] arr = new int[2, 2];
            int i, j;
            Console.WriteLine("Enter the elemets for 2x2 matrix: ");
            for(i = 0; i < 2; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    arr[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Array is: ");
            for(int p = 0; p < 2; p++)
            {
                for(int q = 0; q < 2; q++)
                {
                    Console.Write(arr[p,q] + " ");
                }
                Console.WriteLine();
            }
        }
        void String1()
        {
            string str = "Hello World! Pune";
            Console.WriteLine(str + "\n");

            for(int i = 0; i < str.Length; i++)
            {
                Console.WriteLine(str[i]);
            }

            string msg = "";
            for(int j = 0; j < str.Length; j++)
            {
                if (str[j] != ' ')
                {
                    msg = msg + str[j];
                }
                else
                {
                    Console.WriteLine(msg);
                    msg = "";
                }
            }
            Console.WriteLine(msg);

            string msg1 = "";
            for(int k = 0; k < str.Length; k++)
            {
                if (str[k] != ' ')
                {
                    msg1 = str[k] + msg1;
                }
                else
                {
                    Console.Write(msg1 +" ");
                    msg1 = "";
                }
            }
            Console.WriteLine(msg1 + "\n");

            for(int p = str.Length - 1; p >= 0; p--)
            {
                Console.Write(str[p]);
            }

            Console.WriteLine("\n");

            string msg2 = "";
            for(int q = str.Length -1; q >= 0; q--)
            {
                if (str[q] != ' ')
                {
                    msg2 = str[q] + msg2;
                }
                else
                {
                    Console.Write(msg2 + ' ');
                    msg2 = "";
                }
            }
            Console.WriteLine(msg2);
        }

        // static: we can create only one copy of the static member and member function.
        static int a = 20;
        int b = 10;

        static void Add()
        {
            Console.WriteLine("calling add function.");
        }

        //Constructor:
        // 1) Contructor name and class name is same.
        // 2) It is used to initialize an object.
        // 3) It is used to create an instance of a class.
        // 4) Declaration of a constructor is same as normal function declaration but the difference is constructor has no return type.
        // 5) For single class we can create multiple constructors they are uniquely identified by passing different parameters

        // We can pass the values to the contructor based on the parameters and those types are:
        // 1) Type of Parameter:
        public Program(char b)
        {
            Console.WriteLine("calling char contructor.");
        }
        //public Program(int a)
        //{
        //    Console.WriteLine("calling int contructor.");
        //}

        // 2) Number of Parameter:
        public Program(int a, int b)
        {
            Console.WriteLine("calling int a int b contructor.");
        }

        // 3) Sequence of Parameter:
        public Program(int a, char b)
        {
            Console.WriteLine("calling int a char b contructor.");
        }

        //-------------------------------------------------------------------------------------------------------------

        //Types of Constructor:
        // 1) Default Constructor
        // 2) Parameterised Constructor
        // 3) Copy Constructor
        // 4) Static Constructor
        // 5) Private Constructor

        // 1) default Constructor:
        // Constructor without any parameters is called a default constructor.

        //public Program()
        //{
        //    Console.WriteLine("Calling from default constructor.");
        //}

        //2) Parameterised Constructor:
        // Constructor with atleast one parameters is called a Parameterized constructor.
        public Program(int a, string s)
        {
            Console.WriteLine(a + "" + s);
        }

        // 3) Static Constructor:
        // A static constructor is used to initialize static data members of a class.

        //static Program()
        //{
        //    Console.WriteLine("Calling static member.");
        //}
        //public static void Display()
        //{
        //    Console.WriteLine("Calling from static constructor.");
        //}

        // 4) Copy Constructor:
        // A copy constructor is a user-defined constructor that creates a new
        // object by copying data from an existing object of the same class.
        string p;
        Program p1;
        public Program(string q)
        {
            p = q;
        }
        public Program(Program p2)
        {
            p = p2.p;
        }
        public void Show()
        {
            Console.WriteLine(p);
        }

        // 5) Private Constructor:
        // private constructor prevents other classes from creating an instance (object) of that
        // class using the new keyword.

        //private Program()
        //{
        //    Console.WriteLine("Calling Private Constructor.");
        //}
        //public void Show1()
        //{
        //    Console.WriteLine("Calling display function.");
        //}

        // Destructor:-
        // It is used to destroy unused objects, Means objects which are not no longer in use.
        // Declaration of destructor is same as constructor only difference is destructor has no return type and no access specifire.
        // for destructor we can use the prefix ~ (tilt) symbol.
        // Destructor is called at the end of the program.
        // For single class we can create only one destructor & it is called for every instance.

        public Program()
        {
            Console.WriteLine("Calling default constructor.");
        }
        public Program(int a)
        {
            Console.WriteLine("Calling Parameterised constructor.");
        }
        public void Display()
        {
            Console.WriteLine("Calling display function.");
        }
        ~Program()
        {
            Console.WriteLine("Calling Desctructor.");
        }

        // Managed Code: 
        // The code has automatic memory managemnt it is known as Managed code.
        // The memory mangement is done at the end of the program.
        // For the managed code we are using "Finalize()" method to manage memory.

        // Unmanaged Code:
        // In this code the memory mangement will be done manually.
        // We can do memory mangement whenver required for this no need to wait till end.
        // For this we can use "Dispose()" method which is comes from IDisposibleInterface.

        //Exception :
        // An error occur at runtime known as exception.

        // Exception Handling:
        // It is the process of handling runtime error is known as exception handling.

        //Tyepes of Exceptions:
        // 1) User Defined Exceptions:
        // 2) System Defined Exceptions:

        // 1) User Defined Exceptions:
        // We can create our own exceptions.
        // All user defined exceptions are comes from System.ApplicationExceptions base class.

        public void Additions()
        {
            try
            {
                int i, sum = 100;
                for(i = 10; i < 100; i++)
                {
                    sum += i;
                    if(sum > 100)
                    {
                        throw new UDException("Addition is excced 100.");
                    }
                    else
                    {
                        Console.WriteLine(sum);
                    }
                }
            }
            catch (UDException ex)
            {
                Console.WriteLine(ex.message);
            }
        }

        // 2) System Defined Exceptions:
        // Some exceptions are already defined inside the system.
        // All system defined exceptions are comes from System.Exception base class.

        public void Divide()
        {
            int a = 10, b = 0,c;
            try
            {
                c = a / b;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Message = " + ex);
                //throw;
            }
        }

        
        static void Main(string[] args)
        {
            Program p = new Program();
            //p.Voter(18);
            //p.IfCondition();
            //p.SwitchStatement();
            //p.MultipleOf5();
            //p.Addition();
            //p.MultipleOf10();
            //p.Factorial();
            //p.Prime();
            //p.Fibbonacci1();
            //p.Fibbonacci2();
            //p.PrintWelcome();
            //p.Pattern1();
            //p.Pattern2();
            //p.Pattern3();
            //p.Pattern4();
            //p.Pattern5();
            //p.Pattern6();
            //p.Pattern7(); 
            //p.Pattern8(); 
            //p.Pattern9();
            //p.CountDigits();
            //p.ReverseNumber();
            //p.Pallindrom();
            //p.AmstrongNumber();
            //p.findAmstrong();

            //p.ArrayExamples();
            //p.FirstMax();
            //p.SecondMax();
            //p.ArraySwap();
            //p.ArrayFromUser();
            //p.ArrayFromUser2x2();

            //p.String1();

            //Console.WriteLine(Program.a);
            //Program.Add();
            //Console.WriteLine(p.b);

            // Constructor
            //int a = 10;
            //Program p = new Program(a);
            //Program p1 = new Program('a');
            //Program p2 = new Program(10, 12);
            //Program p3 = new Program(10, 'a');

            //Program p = new Program();
            //Console.WriteLine(p);
            //Program p = new Program(100, "Hello Shubham");
            //Program p = new Program();
            //Program.Display();

            //Program p3 = new Program("Shubham");
            //Program p4 = new Program(p3);
            //p4.Show();

            //Program p = new Program();
            //p.Show1();

            //Program p1 = new Program();
            //Program p2 = new Program(5);
            //p2.Display();

            //Program p = new Program();
            //p.Additions();
            //p.Divide();

            
            Console.ReadLine();
        }
    }
}
