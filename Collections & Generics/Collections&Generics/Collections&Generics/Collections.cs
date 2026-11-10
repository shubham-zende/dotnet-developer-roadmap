using System;
using System.Collections;

namespace CollectionsAndGenerics
{
    internal class Collections
    {
        // Collectios:
        // A Collection is a class or data structure that stores a group of objects and provides methods to perform operations such as:
        //- Add elements.
        //- Remove elements.
        //- Search elements.
        //- Sort elements.
        //- Update elements.
        //- Iterate through elements.


        //Types of Collections in C#:
        // 1) Non-Generic Collections:
        // 2) Generic Collections:

        // 1) Non-Generic Collections:
        // Non-Generic Collections are collections that can store any type of data.
        // Non-Generic Collections are not type-safe and require explicit type casting.

        // types of Non-Generic Collections in C#:
        // 1) ArrayList:
        // 2) Hashtable:
        // 3) Queue:
        // 4) Stack:
        // 5) SortedList:

        // 1) ArrayList:
        // An ArrayList stores multiple elements and dynamically increases or decreases its size. It can store different data types.

        public void ArrayListExample()
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add("Hello");
            list.Add(3.142);
            list.Add(true);

            foreach(var i in list)
            {
                Console.WriteLine(i);
            }

            list.Remove(3.142);
            list.RemoveAt(0);
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }
            list.Add("Hello");
            list.Add(3.142);
            list.Add(true);
            Console.WriteLine(list.Contains("Hello"));

            Console.WriteLine("Sorted ArrayList:");
            list.Sort();
            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

        }

        // 2) Hashtable:
        // A Hashtable stores key-value pairs and allows you to access values using keys. It is not type-safe and requires explicit type casting.

        public void Hashtable()
        {
            Hashtable table = new Hashtable();
            table.Add(1, 23);
            table.Add(2, "Hello");
            table.Add(3, 3.142);
            table.Add(4, true);

            foreach (var i in table)
            {
                Console.Write(i);
            }
            Console.WriteLine(table.Contains(table[2]));
            Console.WriteLine(table.ContainsKey(2));
            table.Remove(1);
            Console.WriteLine(table.ContainsValue(23));

        }

        // 3) Stack:
        // A Stack is a collection that stores elements in a Last-In-First-Out (LIFO) order. It allows you to push and pop elements.
        // It is not type-safe and requires explicit type casting.

        public void Stack()
        {
            Stack s = new Stack();
            s.Push(23);
            s.Push("Hello");
            s.Push(3.142);
            foreach (var i in s)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            s.Push("Hello");
            s.Push(3.142);
            Console.WriteLine(s.Peek());
            s.Clear();
        }

        // 4) Queue:
        // A Queue is a collection that stores elements in a First-In-First-Out (FIFO) order. It allows you to enqueue and dequeue elements.
        // It is not type-safe and requires explicit type casting.

        public void Queue()
        {
            Queue q = new Queue();
            q.Enqueue(23);
            q.Enqueue("Hello");
            q.Enqueue(3.142);
            foreach (var i in q)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Peek());
        }

        // 5) SortedList:
        // A SortedList is a collection that stores key-value pairs in sorted order based on the keys. It allows you to access values using keys.
        // It is not type-safe and requires explicit type casting.

        public void SortedList()
        {
            SortedList list = new SortedList();
            list.Add(2, 234);
            list.Add(1, 21);
            list.Add(5, 345);
            list.Add(4, 51);
            list.Add(3, 79);
            foreach(var i in list)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            foreach(DictionaryEntry i in list)
            {
                Console.WriteLine(i.Key + ":" + i.Value);
            }
            list.Remove(3);
            list.RemoveAt(0);
            Console.WriteLine(list.ContainsKey(2));
            Console.WriteLine(list.ContainsValue(234));
            Console.WriteLine(list.Keys);
            Console.WriteLine(list.Values);
            Console.WriteLine(list.IndexOfKey(1));
            Console.WriteLine(list.IndexOfValue(345));

        }

        // 2) Generic Collections:
        // In C#, Generic Collections are classes provided by the System.Collections.Generic namespace. They allow us to store, manage, and manipulate data in a strongly typed manner.

        // Types of Generic Collections:
        // 1) List
        // 2) Dictionary
        // 3) SortedList
        // 4) SortedDictionary
        // 5) Queue
        // 6) Stack
        // 7) HashSet
        // 8) LinkedList

        // 1) List:
        // List is the generic collection in c#. It is comes from System.Collections.Generics
        // It is the dynamic array so the size can grow or shrink automatically.
        // It is type safe so we can only store the elements of specific type.

        public void MyList()
        {
            List<int> lst = new List<int>();
            lst.Add(1);
            lst.Add(198);
            lst.Add(56);
            lst.Add(243);
            lst.Add(44);
            Console.WriteLine("List elements: ");
            foreach(int i in lst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("------------------------------------");
            lst.Insert(1, 255);
            Console.WriteLine("Inserted List elements: ");
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
            lst.Sort();
            Console.WriteLine("Sorted List elements: ");
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("------------------------------------");
            Console.WriteLine(lst.Min());
            Console.WriteLine(lst.Max());
            Console.WriteLine(lst.Sum());
            Console.WriteLine(lst.Average());
            Console.WriteLine("------------------------------------");
            lst.Reverse();
            Console.WriteLine("Reversed List elements: ");
            foreach (int i in lst)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(lst.Count());
        }

        // 2) SortedList:
        // SortedList is a collection of key-value pairs, stored by key.
        // Key must be unique.
        // values can be duplicate.
        // Automatically keeps elements sorted by key(Ascending order.)

        public void MySortedList()
        {
            SortedList<int, string> sl = new SortedList<int, string>(2);
            sl.Add(1, "Shubham");
            sl.Add(2, "Pratik");
            sl.Add(4, "Pramod");
            sl.Add(3, "Vaibhav");


            foreach(var i in sl)
            {
                Console.WriteLine(i);
            }
        }
        // 3) Dictionary:
        // - A Dictionary<TKey, TValue> is a generic collection in C#.
        // - Belongs to system.collections.generics
        // - Key must be unique and value can be duplicate.
        // - Lookup is very fast (It uses hashing internally.)

        public void MyDict()
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(5, "Shubham");
            dict.Add(3, "Pratik");
            dict.Add(2, "Swaraj");
            dict.Add(4, "Mahesh");
            dict.Add(1, "Swagat");

            foreach(var i in dict)
            {
                Console.WriteLine($"{i.Key} = {i.Value}");
            }
            Console.WriteLine("Remove Key method.");
            Console.WriteLine(dict.Remove(2));

            Console.WriteLine("Count = ",dict.Count);

            Console.WriteLine("Keys : ", dict.Keys);
        }
    }
}
