using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    // Generic class:
    // This class can be used to store any type of data.
    // Generic allows you to create type-safe classes, methods, and collections.
    // Insead of writing code every time for every data type, you can write a generic class once and use it for any data type.
    // It is also beneficial for code reusability and maintainability.

    // Problems:
    //- No compile-time type safety.
    //- Requires explicit type casting.
    //- Can cause runtime errors if the wrong type is used.
    //- Boxing and unboxing can occur with value types.

    // Types of Generics in C#:
    // 1) Generic Classes:
    // A class that accepts a type parameter.
    public class Data<T>
    {

        // 2) Generic Methods:
        // A method that accepts a generic type parameter.
        public T GetData(T Value)
        {
            return Value;
        }

        public void Display<T>(T Value)
        {
            Console.WriteLine(Value);
        }

        // 3. Generic Interface
        //An interface that accepts a type parameter.

        //4. Generic Delegate
        // A delegate that works with generic types.
        // C# provides built-in generic delegates:

        //Func
        
        // Returns a value.
        public void GetFunc()
        {
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(5, 10));
        }
    }
}
