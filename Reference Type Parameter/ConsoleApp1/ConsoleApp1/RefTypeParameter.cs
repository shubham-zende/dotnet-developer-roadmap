using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeParameter
{
    public class RefTypeParameter
    {
        // ref:
        // The ref keyword is used to pass a parameter by reference. This means that any changes made to the parameter inside the method will be reflected outside the method as well.
        // When you use ref, the variable must be initialized before it is passed to the method.

        public void Display(ref int x, ref int y)
        {
            x = x + y;
            y = x - y;
            x = x - y;
            Console.WriteLine($"After swapping : x = {x} , y = {y}");
        }

        // Out:
        // The out keyword is used to pass parameter by reference.
        // It allows a method to return multiple values.
        // The out paramerter doesn't need to be initialized before calling the method.
        // But inside the method must be assigned.

        public void Show(int a, int b, out int x, out int y)
        {
            x = a + b;
            y = a - b;
            Console.WriteLine($"x = {x} and y = {y}");
        }

        // in :
        // The in keyword is used to pass a parameter by reference, but it is read-only.
        // the method cannot modify the parameter value.

        public void ShowInPara(in int x)
        {
            Console.WriteLine($"Value of x is: {x}");
        }
    }
}
