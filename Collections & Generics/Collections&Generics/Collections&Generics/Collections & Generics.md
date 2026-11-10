# C# Collections: Non-Generic and Generic Collections

A practical interview and revision guide covering definitions, use cases, examples, commonly used built-in methods/properties, and interview questions with answers.

## 1. What is a collection in C#?

A **collection** is an object that stores and manages a group of objects. Collections make it easier to add, remove, search, sort, and iterate over data.

C# collection types are commonly grouped into:

- **Non-generic collections** — mainly in `System.Collections`; they store values as `object`, so value types may require boxing/unboxing and explicit casting.
- **Generic collections** — mainly in `System.Collections.Generic`; they use type parameters such as `List<int>` and provide compile-time type safety.

> Prefer generic collections in new code in most situations. Use non-generic collections mainly when maintaining older code or when an API specifically requires them.

## 2. Required namespaces

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
```

---

# Part A — Non-Generic Collections

## 3. ArrayList

### Definition
`ArrayList` is a non-generic, dynamically sized collection. It can store objects of different data types because each item is treated as `object`.

### Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        ArrayList items = new ArrayList();

        items.Add(10);
        items.Add("Shubham");
        items.Add(25.5);

        Console.WriteLine(items[0]); // 10
        Console.WriteLine(items[1]); // Shubham

        foreach (object item in items)
        {
            Console.WriteLine(item);
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of elements currently stored |
| `Capacity` | Number of elements the internal storage can hold before resizing |
| `Add(value)` | Adds one item to the end |
| `AddRange(collection)` | Adds items from another collection |
| `Insert(index, value)` | Inserts an item at a specified index |
| `InsertRange(index, collection)` | Inserts multiple items at an index |
| `Remove(value)` | Removes the first matching item |
| `RemoveAt(index)` | Removes the item at an index |
| `RemoveRange(index, count)` | Removes a range of items |
| `Contains(value)` | Checks whether an item exists |
| `IndexOf(value)` | Returns the first matching index, or `-1` |
| `Clear()` | Removes all items |
| `Sort()` | Sorts items; items must be mutually comparable |
| `Reverse()` | Reverses the order |
| `ToArray()` | Copies items into an array |
| `TrimToSize()` | Reduces capacity to the current count |

### Important points
- It grows automatically when more elements are added.
- It can contain mixed types.
- It does not provide compile-time type safety.
- Retrieving an item as a specific type may require casting.
- For value types, storing in an `ArrayList` can involve boxing and retrieving can involve unboxing.

---

## 4. Hashtable

### Definition
`Hashtable` stores data as **key-value pairs**. Each key must be unique and cannot be `null`. Values can be `null`.

A hash function is used to locate values by key. A hashtable does not maintain items in sorted order.

### Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Hashtable employees = new Hashtable();

        employees.Add(101, "Amit");
        employees.Add(102, "Neha");
        employees.Add(103, "Rahul");

        Console.WriteLine(employees[102]); // Neha

        if (employees.ContainsKey(101))
        {
            Console.WriteLine("Employee exists");
        }

        foreach (DictionaryEntry entry in employees)
        {
            Console.WriteLine($"Key: {entry.Key}, Value: {entry.Value}");
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of key-value pairs |
| `Keys` | Collection of keys |
| `Values` | Collection of values |
| `Add(key, value)` | Adds a pair; throws if the key already exists |
| `Remove(key)` | Removes the pair for a key |
| `ContainsKey(key)` | Checks whether a key exists |
| `Contains(value)` | Checks whether a value exists |
| `ContainsValue(value)` | Checks whether a value exists |
| `Clear()` | Removes all pairs |
| `Clone()` | Creates a shallow copy |
| `GetEnumerator()` | Gets an enumerator |
| `Item[key]` / `table[key]` | Gets or sets the value for a key |

### Important points
- Keys must be unique.
- Keys cannot be `null`; values may be `null`.
- Enumeration order is not guaranteed to be sorted.
- Use `Dictionary<TKey, TValue>` for most new code.

---

## 5. Queue

### Definition
A `Queue` is a non-generic collection that follows **FIFO (First In, First Out)**. The first item added is the first item removed.

Think of a line of people waiting at a counter.

### Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Queue queue = new Queue();

        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Enqueue("C");

        Console.WriteLine(queue.Peek());    // A
        Console.WriteLine(queue.Dequeue()); // A
        Console.WriteLine(queue.Dequeue()); // B

        Console.WriteLine(queue.Count);     // 1
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of items |
| `Enqueue(value)` | Adds an item at the end |
| `Dequeue()` | Removes and returns the item at the front |
| `Peek()` | Returns the front item without removing it |
| `Contains(value)` | Checks whether an item exists |
| `Clear()` | Removes all items |
| `ToArray()` | Copies items into an array |
| `TrimToSize()` | Reduces capacity to the current count |

### Important points
- FIFO order.
- `Dequeue()` and `Peek()` throw `InvalidOperationException` when the queue is empty.
- Check `Count` before removing or peeking if the queue may be empty.

---

## 6. Stack

### Definition
A `Stack` is a non-generic collection that follows **LIFO (Last In, First Out)**. The last item added is the first item removed.

Think of a stack of plates.

### Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Stack stack = new Stack();

        stack.Push("A");
        stack.Push("B");
        stack.Push("C");

        Console.WriteLine(stack.Peek()); // C
        Console.WriteLine(stack.Pop());  // C
        Console.WriteLine(stack.Pop());  // B

        Console.WriteLine(stack.Count);  // 1
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of items |
| `Push(value)` | Adds an item to the top |
| `Pop()` | Removes and returns the top item |
| `Peek()` | Returns the top item without removing it |
| `Contains(value)` | Checks whether an item exists |
| `Clear()` | Removes all items |
| `ToArray()` | Copies items into an array |
| `TrimToSize()` | Reduces capacity to the current count |

### Important points
- LIFO order.
- `Pop()` and `Peek()` throw `InvalidOperationException` when the stack is empty.
- Common uses include undo operations, parsing, and tracking method calls.

---

## 7. SortedList (Non-Generic)

### Definition
The non-generic `SortedList` stores key-value pairs and automatically sorts them by **key**. Keys must be unique. It supports access by key and by numeric index.

### Example

```csharp
using System;
using System.Collections;

class Program
{
    static void Main()
    {
        SortedList students = new SortedList();

        students.Add(103, "Rahul");
        students.Add(101, "Amit");
        students.Add(102, "Neha");

        foreach (DictionaryEntry entry in students)
        {
            Console.WriteLine($"{entry.Key} - {entry.Value}");
        }

        Console.WriteLine(students.GetByIndex(0)); // Amit
        Console.WriteLine(students.GetKey(0));     // 101
        Console.WriteLine(students[102]);          // Neha
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of pairs |
| `Keys` | Sorted collection of keys |
| `Values` | Values in key order |
| `Add(key, value)` | Adds a pair |
| `Remove(key)` | Removes a pair by key |
| `RemoveAt(index)` | Removes a pair at a numeric index |
| `ContainsKey(key)` | Checks for a key |
| `ContainsValue(value)` | Checks for a value |
| `GetKey(index)` | Gets the key at an index |
| `GetByIndex(index)` | Gets the value at an index |
| `SetByIndex(index, value)` | Sets the value at an index |
| `IndexOfKey(key)` | Gets the index of a key |
| `IndexOfValue(value)` | Gets the index of a value |
| `Clear()` | Removes all pairs |

### Important points
- Items are sorted by key, not by value.
- Keys must be unique and non-null.
- Inserting an item can require shifting later entries, so insertion can be more expensive than in a dictionary.
- Do not confuse this with `SortedList<TKey, TValue>`.

---

# Part B — Generic Collections

## 8. List<T>

### Definition
`List<T>` is a strongly typed, dynamically sized collection. `T` specifies the type of items allowed in the list.

For example, `List<int>` stores integers and `List<string>` stores strings.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> names = new List<string>();

        names.Add("Amit");
        names.Add("Neha");
        names.Add("Rahul");

        Console.WriteLine(names[0]); // Amit

        names.Insert(1, "Priya");
        names.Remove("Rahul");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of items |
| `Capacity` | Current allocated storage capacity |
| `Add(item)` | Adds one item |
| `AddRange(collection)` | Adds multiple items |
| `Insert(index, item)` | Inserts at an index |
| `InsertRange(index, collection)` | Inserts multiple items |
| `Remove(item)` | Removes the first matching item |
| `RemoveAt(index)` | Removes at an index |
| `RemoveRange(index, count)` | Removes a range |
| `RemoveAll(predicate)` | Removes all items matching a condition |
| `Contains(item)` | Checks whether an item exists |
| `IndexOf(item)` | Finds the first matching index |
| `Find(predicate)` | Finds the first matching item |
| `FindAll(predicate)` | Returns all matching items |
| `FindIndex(predicate)` | Finds the index of a matching item |
| `Exists(predicate)` | Checks whether any item matches |
| `TrueForAll(predicate)` | Checks whether all items match |
| `Sort()` / `Sort(comparer)` | Sorts items |
| `Reverse()` | Reverses the list |
| `ForEach(action)` | Executes an action for each item |
| `Clear()` | Removes all items |
| `ToArray()` | Copies items into an array |

### Example using `Find`, `FindAll`, and `RemoveAll`

```csharp
List<int> numbers = new List<int> { 10, 15, 20, 25, 30 };

int firstEven = numbers.Find(n => n % 2 == 0);
List<int> evens = numbers.FindAll(n => n % 2 == 0);

numbers.RemoveAll(n => n < 20);

Console.WriteLine(firstEven); // 10
Console.WriteLine(string.Join(", ", evens)); // 10, 20, 30
Console.WriteLine(string.Join(", ", numbers)); // 20, 25, 30
```

### Important points
- Type-safe: `List<int>` cannot accept a string.
- Supports index-based access.
- Automatically grows as needed.
- Good for general-purpose, ordered collections with frequent indexed access.

---

## 9. Dictionary<TKey, TValue>

### Definition
`Dictionary<TKey, TValue>` stores strongly typed key-value pairs. Each key must be unique. It uses hashing to support fast key-based lookup on average.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<int, string> employees =
            new Dictionary<int, string>();

        employees.Add(101, "Amit");
        employees.Add(102, "Neha");
        employees.Add(103, "Rahul");

        Console.WriteLine(employees[102]); // Neha

        if (employees.TryGetValue(101, out string employee))
        {
            Console.WriteLine(employee);
        }

        foreach (KeyValuePair<int, string> item in employees)
        {
            Console.WriteLine($"{item.Key} - {item.Value}");
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of pairs |
| `Keys` | Collection of keys |
| `Values` | Collection of values |
| `Add(key, value)` | Adds a pair; duplicate keys cause an exception |
| `TryAdd(key, value)` | Adds only if the key does not already exist |
| `Remove(key)` | Removes a pair by key |
| `ContainsKey(key)` | Checks whether a key exists |
| `ContainsValue(value)` | Checks whether a value exists |
| `TryGetValue(key, out value)` | Safely attempts to retrieve a value |
| `Clear()` | Removes all pairs |
| `GetValueOrDefault(key)` | Gets a value or the default value if absent (available on modern .NET) |

### Important points
- Keys are unique; values do not have to be unique.
- A key cannot be `null` for the standard `Dictionary<TKey, TValue>` implementation.
- Use `TryGetValue` when a key may not exist; direct indexer access throws `KeyNotFoundException` for a missing key.
- Lookup, insertion, and removal are generally O(1) on average, but can be O(n) in the worst case.
- Do not rely on dictionary enumeration order as a sorting guarantee.

---

## 10. SortedList<TKey, TValue> (Generic)

### Definition
`SortedList<TKey, TValue>` stores key-value pairs sorted by key. It supports lookup by key and access by numeric index.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedList<int, string> students =
            new SortedList<int, string>();

        students.Add(103, "Rahul");
        students.Add(101, "Amit");
        students.Add(102, "Neha");

        foreach (KeyValuePair<int, string> student in students)
        {
            Console.WriteLine($"{student.Key} - {student.Value}");
        }

        Console.WriteLine(students.Keys[0]);   // 101
        Console.WriteLine(students.Values[0]); // Amit
        Console.WriteLine(students.IndexOfKey(102)); // 1
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of pairs |
| `Capacity` | Allocated capacity |
| `Keys` / `Values` | Sorted keys and corresponding values |
| `Add(key, value)` | Adds a pair |
| `Remove(key)` | Removes by key |
| `RemoveAt(index)` | Removes by index |
| `ContainsKey(key)` | Checks for a key |
| `ContainsValue(value)` | Checks for a value |
| `IndexOfKey(key)` | Finds the key's index |
| `IndexOfValue(value)` | Finds the value's index |
| `Clear()` | Removes all pairs |
| `TryGetValue(key, out value)` | Attempts to get a value |

### Important points
- Maintains keys in sorted order.
- Supports index-based access.
- Lookup by key is O(log n); insertion and removal can be O(n) because elements may need shifting.
- Useful when sorted order and indexed access are both needed.

---

## 11. SortedDictionary<TKey, TValue>

### Definition
`SortedDictionary<TKey, TValue>` stores key-value pairs in sorted key order, typically using a balanced search tree.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedDictionary<int, string> employees =
            new SortedDictionary<int, string>();

        employees.Add(103, "Rahul");
        employees.Add(101, "Amit");
        employees.Add(102, "Neha");

        foreach (KeyValuePair<int, string> employee in employees)
        {
            Console.WriteLine($"{employee.Key} - {employee.Value}");
        }
    }
}
```

Output is in ascending key order: `101`, `102`, `103`.

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of pairs |
| `Keys` / `Values` | Sorted keys and corresponding values |
| `Add(key, value)` | Adds a pair |
| `TryAdd(key, value)` | Adds only if the key is absent |
| `Remove(key)` | Removes by key |
| `ContainsKey(key)` | Checks for a key |
| `ContainsValue(value)` | Checks for a value |
| `TryGetValue(key, out value)` | Attempts to retrieve a value |
| `Clear()` | Removes all pairs |

### Important points
- Keys are kept sorted.
- Lookup, insertion, and removal are O(log n).
- Unlike `SortedList<TKey, TValue>`, it does not provide numeric index access.
- Useful when sorted order is required and items are frequently inserted or removed.

---

## 12. Queue<T>

### Definition
`Queue<T>` is a generic, strongly typed FIFO collection.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> tasks = new Queue<string>();

        tasks.Enqueue("Task 1");
        tasks.Enqueue("Task 2");
        tasks.Enqueue("Task 3");

        Console.WriteLine(tasks.Peek());    // Task 1
        Console.WriteLine(tasks.Dequeue()); // Task 1

        foreach (string task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of items |
| `Enqueue(item)` | Adds at the end |
| `Dequeue()` | Removes and returns the front item |
| `Peek()` | Reads the front item without removing it |
| `TryDequeue(out item)` | Removes an item safely if available |
| `TryPeek(out item)` | Reads the front item safely if available |
| `Contains(item)` | Checks for an item |
| `Clear()` | Removes all items |
| `ToArray()` | Copies items into an array |

### Important points
- FIFO: first added, first removed.
- `Dequeue()` and `Peek()` throw when empty.
- `TryDequeue` and `TryPeek` are useful when the queue may be empty.

---

## 13. Stack<T>

### Definition
`Stack<T>` is a generic, strongly typed LIFO collection.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> pages = new Stack<string>();

        pages.Push("Home");
        pages.Push("Products");
        pages.Push("Details");

        Console.WriteLine(pages.Peek()); // Details
        Console.WriteLine(pages.Pop());  // Details

        foreach (string page in pages)
        {
            Console.WriteLine(page);
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of items |
| `Push(item)` | Adds an item to the top |
| `Pop()` | Removes and returns the top item |
| `Peek()` | Reads the top item without removing it |
| `TryPop(out item)` | Removes an item safely if available |
| `TryPeek(out item)` | Reads the top item safely if available |
| `Contains(item)` | Checks for an item |
| `Clear()` | Removes all items |
| `ToArray()` | Copies items into an array |

### Important points
- LIFO: last added, first removed.
- `Pop()` and `Peek()` throw when empty.
- Common uses include undo/redo, expression evaluation, and depth-first traversal.

---

## 14. HashSet<T>

### Definition
`HashSet<T>` stores unique elements. Adding an item that is already present does not create a duplicate.

It uses hashing and is useful for membership checks and set operations.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<int> numbers = new HashSet<int>();

        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(10); // Duplicate; not added

        Console.WriteLine(numbers.Count); // 2
        Console.WriteLine(numbers.Contains(20)); // True

        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of unique items |
| `Add(item)` | Adds an item; returns `true` if added |
| `Remove(item)` | Removes an item |
| `Contains(item)` | Checks membership |
| `TryGetValue(equalValue, out actualValue)` | Gets the stored value equal to the supplied value |
| `UnionWith(collection)` | Adds all items from another set |
| `IntersectWith(collection)` | Keeps only common items |
| `ExceptWith(collection)` | Removes items found in another collection |
| `SymmetricExceptWith(collection)` | Keeps items present in exactly one of the sets |
| `IsSubsetOf(collection)` | Checks whether this set is a subset |
| `IsSupersetOf(collection)` | Checks whether this set is a superset |
| `Overlaps(collection)` | Checks whether any item is shared |
| `SetEquals(collection)` | Checks whether both contain the same set of items |
| `Clear()` | Removes all items |

### Important points
- Duplicate elements are not stored.
- Does not guarantee sorted or insertion order.
- Average membership checks are O(1).
- Equality and uniqueness depend on the equality comparer used.

---

## 15. LinkedList<T>

### Definition
`LinkedList<T>` is a doubly linked list. Each node stores a value and links to the previous and next nodes.

It supports efficient insertion and removal when you already have the relevant node.

### Example

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<string> names = new LinkedList<string>();

        LinkedListNode<string> first = names.AddFirst("Amit");
        names.AddLast("Rahul");
        names.AddAfter(first, "Neha");
        names.AddBefore(first, "Priya");

        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        names.Remove("Rahul");
    }
}
```

### Common properties and methods

| Member | Description |
|---|---|
| `Count` | Number of nodes |
| `First` / `Last` | First and last nodes |
| `AddFirst(value)` | Adds a node at the beginning |
| `AddLast(value)` | Adds a node at the end |
| `AddBefore(node, value)` | Adds before a known node |
| `AddAfter(node, value)` | Adds after a known node |
| `Find(value)` | Finds the first matching node |
| `FindLast(value)` | Finds the last matching node |
| `Remove(value)` | Removes the first matching value |
| `Remove(node)` | Removes a known node |
| `RemoveFirst()` | Removes the first node |
| `RemoveLast()` | Removes the last node |
| `Clear()` | Removes all nodes |

### Important points
- It is doubly linked: nodes have previous and next links.
- No index-based access such as `list[2]`.
- Finding an item is O(n).
- Insertion/removal at a known node is O(1).
- Useful when frequent insertions/removals occur at known positions.

---

# Part C — Comparison and Selection

## 16. Non-Generic vs Generic Collections

| Feature | Non-generic | Generic |
|---|---|---|
| Namespace | `System.Collections` | `System.Collections.Generic` |
| Type safety | Not compile-time type-safe | Compile-time type-safe |
| Stored values | Treated as `object` | Specific type `T` |
| Casting | Often required | Usually not required |
| Boxing/unboxing | Can occur for value types | Avoided for value types stored in matching generic collections |
| Performance | Can have extra conversion overhead | Usually more efficient for typed data |
| Preferred for new code | Generally no | Yes |

## 17. Collection selection guide

| Requirement | Recommended collection |
|---|---|
| General resizable list with index access | `List<T>` |
| Key-value lookup by unique key | `Dictionary<TKey, TValue>` |
| Key-value data always sorted by key; frequent inserts/removals | `SortedDictionary<TKey, TValue>` |
| Sorted key-value data with index access | `SortedList<TKey, TValue>` |
| First-in, first-out processing | `Queue<T>` |
| Last-in, first-out processing | `Stack<T>` |
| Unique items and set operations | `HashSet<T>` |
| Frequent insert/remove around known nodes | `LinkedList<T>` |

## 18. Time complexity overview

These are typical/average complexities for common implementations; exact behavior can depend on comparers, hashing, and input.

| Collection | Lookup | Add | Remove |
|---|---:|---:|---:|
| `List<T>` by value | O(n) | O(1) amortized at end | O(n) |
| `Dictionary<TKey,TValue>` by key | O(1) average | O(1) average | O(1) average |
| `HashSet<T>` | O(1) average | O(1) average | O(1) average |
| `SortedList<TKey,TValue>` by key | O(log n) | O(n) | O(n) |
| `SortedDictionary<TKey,TValue>` by key | O(log n) | O(log n) | O(log n) |
| `Queue<T>` front operation | O(1) | O(1) | O(1) |
| `Stack<T>` top operation | O(1) | O(1) | O(1) |
| `LinkedList<T>` by value | O(n) | O(1) at known node | O(1) at known node |

---

# Part D — Interview Questions and Answers

## 19. Basic interview questions

### Q1. What is a collection in C#?
**Answer:** A collection is an object used to store and manage multiple items. It provides operations such as adding, removing, searching, and iterating over items.

### Q2. What are the main categories of collections in C#?
**Answer:** Two commonly discussed categories are non-generic collections in `System.Collections` and generic collections in `System.Collections.Generic`.

### Q3. What is the difference between generic and non-generic collections?
**Answer:** Non-generic collections store items as `object`, so casting may be needed and value types may be boxed. Generic collections specify the item type, provide compile-time type safety, and usually avoid those conversions.

### Q4. Why should we prefer generic collections?
**Answer:** They provide type safety, reduce casting, avoid boxing/unboxing for matching value types, and make code easier to maintain.

### Q5. What is `ArrayList`?
**Answer:** `ArrayList` is a non-generic, resizable collection that stores items as `object` and can contain different data types.

### Q6. What is the difference between an array and `ArrayList`?
**Answer:** An array has a fixed length after creation and stores elements of its declared type. `ArrayList` can grow or shrink and stores items as `object`.

### Q7. What is `List<T>`?
**Answer:** `List<T>` is a generic, dynamically sized collection that stores elements of a specified type and supports index-based access.

### Q8. What is boxing and unboxing?
**Answer:** Boxing converts a value type to `object` or an implemented interface type. Unboxing extracts the value type from the boxed object and requires the correct type.

```csharp
int number = 10;
object boxed = number;       // Boxing
int result = (int)boxed;     // Unboxing
```

### Q9. What is a `Hashtable`?
**Answer:** A `Hashtable` stores key-value pairs, uses hashing for key-based lookup, and does not guarantee sorted order.

### Q10. What is a `Dictionary<TKey, TValue>`?
**Answer:** It is the generic equivalent commonly used for key-value storage. It enforces unique keys and provides type-safe access.

### Q11. Can a dictionary contain duplicate keys?
**Answer:** No. Each key must be unique. Adding an existing key with `Add` throws an exception. Use the indexer to update an existing key or `TryAdd` to attempt an add without throwing for a duplicate.

### Q12. Can a dictionary contain duplicate values?
**Answer:** Yes. Values do not need to be unique.

### Q13. What is the difference between `Hashtable` and `Dictionary`?
**Answer:** `Hashtable` is non-generic and stores keys/values as objects. `Dictionary<TKey, TValue>` is generic and type-safe. For most new applications, use `Dictionary`.

### Q14. What is a `Queue`?
**Answer:** A queue is a FIFO collection. Items are added at the rear and removed from the front.

### Q15. What is a `Stack`?
**Answer:** A stack is a LIFO collection. Items are added and removed from the top.

### Q16. What is the difference between `Peek()` and `Pop()`?
**Answer:** `Peek()` returns the next item without removing it. `Pop()` returns and removes it.

### Q17. What is the difference between `Enqueue()` and `Dequeue()`?
**Answer:** `Enqueue()` adds an item to a queue. `Dequeue()` removes and returns the item at the front.

### Q18. What is `HashSet<T>`?
**Answer:** It is a generic collection that stores unique elements and supports efficient membership checks and set operations.

### Q19. Does `HashSet<T>` maintain insertion order?
**Answer:** No ordering guarantee should be relied upon. If sorted output is required, sort the values or use an appropriate sorted collection.

### Q20. What is `LinkedList<T>`?
**Answer:** It is a doubly linked list whose nodes refer to the previous and next nodes. It is useful for efficient changes around a known node.

## 20. Comparison-based interview questions

### Q21. Difference between `List<T>` and `LinkedList<T>`?
**Answer:** `List<T>` uses an array internally and provides fast index access. `LinkedList<T>` uses linked nodes, has no index access, and supports O(1) insertion/removal when the node is already known.

### Q22. Difference between `Dictionary` and `SortedDictionary`?
**Answer:** `Dictionary` is optimized for fast key lookup and does not guarantee sorted enumeration. `SortedDictionary` keeps keys sorted and has O(log n) lookup, insertion, and removal.

### Q23. Difference between `SortedList` and `SortedDictionary`?
**Answer:** Both maintain sorted keys. `SortedList` uses array-based storage, supports index access, and can have O(n) insertion/removal. `SortedDictionary` uses a tree-based structure, has O(log n) operations, and does not offer numeric index access.

### Q24. Difference between `Queue<T>` and `Stack<T>`?
**Answer:** Queue uses FIFO; stack uses LIFO. A queue processes the oldest item first, while a stack processes the newest item first.

### Q25. Difference between `HashSet<T>` and `List<T>`?
**Answer:** A list allows duplicates and maintains positional order with index access. A hash set stores unique items and is optimized for membership checks.

### Q26. Which collection would you use to store employee details by employee ID?
**Answer:** `Dictionary<int, Employee>` is a good choice when employee ID is unique and quick lookup by ID is needed.

### Q27. Which collection would you use to process customer requests in arrival order?
**Answer:** `Queue<CustomerRequest>`, because it follows FIFO.

### Q28. Which collection would you use to implement an undo feature?
**Answer:** `Stack<Command>` or another suitable stack type, because the most recent action is normally undone first.

### Q29. Which collection would you use to remove duplicate IDs?
**Answer:** `HashSet<int>`, because it stores only unique values.

### Q30. Which collection would you use when records must always be iterated in key order and updates are frequent?
**Answer:** `SortedDictionary<TKey, TValue>` is often suitable because it keeps keys sorted and supports O(log n) insertions and removals.

## 21. Scenario-based interview questions

### Q31. You receive 10,000 employee records and need to find an employee by ID repeatedly. Which collection would you choose?
**Answer:** Use `Dictionary<int, Employee>`. Build the dictionary using employee ID as the key, then use `TryGetValue` for safe lookups.

```csharp
Dictionary<int, Employee> employeeById = employees
    .ToDictionary(e => e.Id);

if (employeeById.TryGetValue(101, out Employee employee))
{
    Console.WriteLine(employee.Name);
}
```

### Q32. An API receives repeated product IDs. You need only unique IDs. What would you use?
**Answer:** Use `HashSet<int>`.

```csharp
HashSet<int> uniqueProductIds = new HashSet<int>(productIds);
```

### Q33. A background worker must process jobs in the same order they arrive. What would you use?
**Answer:** Use `Queue<Job>` and call `Enqueue` when a job arrives and `Dequeue` when processing the next job. For concurrent producers/consumers, consider `ConcurrentQueue<T>`.

### Q34. You need to show the latest browser page first in a history operation. What would you use?
**Answer:** A `Stack<string>` is appropriate for a simple last-visited-first behavior.

### Q35. You need to maintain student marks sorted by student ID. Which collection is suitable?
**Answer:** Use `SortedDictionary<int, decimal>` if sorted keys and frequent updates are needed. Use `SortedList<int, decimal>` if indexed access is also useful and updates are relatively infrequent.

### Q36. You need to insert an item between two known nodes in a sequence. Which collection would you choose?
**Answer:** `LinkedList<T>`, because `AddBefore` and `AddAfter` can insert around a known node efficiently.

### Q37. You used `Dictionary` and received a `KeyNotFoundException`. Why?
**Answer:** The requested key did not exist when the dictionary indexer was accessed. Check with `ContainsKey` or preferably use `TryGetValue`.

### Q38. Your queue may be empty. How can you avoid an exception?
**Answer:** Check `Count` before calling `Dequeue`, or use `TryDequeue`.

```csharp
if (queue.TryDequeue(out string nextTask))
{
    Console.WriteLine(nextTask);
}
else
{
    Console.WriteLine("No tasks available");
}
```

### Q39. You need to sort a list of employees by salary. What would you do?
**Answer:** Use `List<Employee>.Sort` with a comparer or LINQ `OrderBy`.

```csharp
employees.Sort((a, b) => a.Salary.CompareTo(b.Salary));
// Or:
var sortedEmployees = employees.OrderBy(e => e.Salary).ToList();
```

### Q40. You need to remove all inactive employees from a list. Which method can help?
**Answer:** Use `RemoveAll` with a predicate.

```csharp
employees.RemoveAll(e => !e.IsActive);
```

### Q41. A collection must prevent duplicate email addresses, ignoring letter case. What would you use?
**Answer:** Use a `HashSet<string>` with `StringComparer.OrdinalIgnoreCase`.

```csharp
HashSet<string> emails =
    new HashSet<string>(StringComparer.OrdinalIgnoreCase);

emails.Add("USER@example.com");
bool added = emails.Add("user@example.com"); // false
```

### Q42. You need a collection that supports fast access by index. What would you use?
**Answer:** `List<T>` or an array. `List<T>` is suitable when the number of elements may change.

### Q43. You need sorted keys but cannot afford O(n) insertion shifts for a large frequently updated collection. What would you use?
**Answer:** Consider `SortedDictionary<TKey, TValue>`, whose tree-based operations are O(log n).

### Q44. Can you use a `List<T>` in a multi-threaded application?
**Answer:** Yes, but a normal `List<T>` is not thread-safe for concurrent modifications. Use synchronization or a suitable concurrent collection such as `ConcurrentBag<T>`, `ConcurrentQueue<T>`, or `ConcurrentDictionary<TKey, TValue>` depending on the requirement.

### Q45. A manager asks you to return an empty collection instead of `null` from a repository method. Why is that useful?
**Answer:** Returning an empty collection gives callers a consistent result and allows safe iteration without a null check. It distinguishes “no records” from “no collection object.”

```csharp
public List<Employee> GetEmployees()
{
    return new List<Employee>(); // when there are no records
}
```

---

# Part E — Practical Coding Exercises

## 22. Count the frequency of each word using a Dictionary

```csharp
string[] words = { "dotnet", "csharp", "dotnet", "sql", "csharp", "dotnet" };

Dictionary<string, int> frequency = new Dictionary<string, int>();

foreach (string word in words)
{
    if (frequency.TryGetValue(word, out int count))
    {
        frequency[word] = count + 1;
    }
    else
    {
        frequency[word] = 1;
    }
}

foreach (var item in frequency)
{
    Console.WriteLine($"{item.Key}: {item.Value}");
}
```

## 23. Find duplicate numbers using HashSet

```csharp
int[] numbers = { 1, 2, 3, 2, 4, 1, 5 };
HashSet<int> seen = new HashSet<int>();
HashSet<int> duplicates = new HashSet<int>();

foreach (int number in numbers)
{
    if (!seen.Add(number))
    {
        duplicates.Add(number);
    }
}

Console.WriteLine(string.Join(", ", duplicates));
```

## 24. Reverse a string using Stack

```csharp
string input = "DOTNET";
Stack<char> characters = new Stack<char>();

foreach (char ch in input)
{
    characters.Push(ch);
}

string reversed = "";

while (characters.Count > 0)
{
    reversed += characters.Pop();
}

Console.WriteLine(reversed); // TEN TOD
```

For production code, `StringBuilder` is generally more efficient than repeated string concatenation.

## 25. Simple Queue example

```csharp
Queue<string> requests = new Queue<string>();

requests.Enqueue("Request 1");
requests.Enqueue("Request 2");
requests.Enqueue("Request 3");

while (requests.TryDequeue(out string request))
{
    Console.WriteLine($"Processing {request}");
}
```

---

# Part F — Important Interview Notes

## 26. Common mistakes to avoid

1. **Using `Dictionary[key]` without checking the key:** it throws if the key is missing. Prefer `TryGetValue`.
2. **Calling `Pop`, `Peek`, or `Dequeue` on an empty collection:** check `Count` or use `TryPop`, `TryPeek`, `TryDequeue`.
3. **Assuming `Dictionary` or `HashSet` is sorted:** use a sorted collection or sort the result when order matters.
4. **Using non-generic collections in new code without a reason:** prefer generic collections.
5. **Assuming `LinkedList<T>` has indexes:** it does not support `list[index]`.
6. **Assuming `List<T>.Remove(value)` removes every match:** it removes only the first matching item. Use `RemoveAll` to remove all matching items.
7. **Assuming collections are automatically thread-safe:** most standard generic collections are not safe for concurrent writes.

## 27. Quick revision sheet

| Collection | Core concept | Key methods |
|---|---|---|
| `ArrayList` | Non-generic resizable list | `Add`, `Remove`, `Insert`, `Sort` |
| `Hashtable` | Non-generic key-value pairs | `Add`, `Remove`, `ContainsKey` |
| `Queue` | Non-generic FIFO | `Enqueue`, `Dequeue`, `Peek` |
| `Stack` | Non-generic LIFO | `Push`, `Pop`, `Peek` |
| `SortedList` | Non-generic sorted key-value pairs | `Add`, `GetKey`, `GetByIndex` |
| `List<T>` | Generic resizable list | `Add`, `Remove`, `Find`, `Sort` |
| `Dictionary<TKey,TValue>` | Generic key-value lookup | `Add`, `TryGetValue`, `Remove` |
| `SortedList<TKey,TValue>` | Sorted keys with index access | `Add`, `IndexOfKey`, `RemoveAt` |
| `SortedDictionary<TKey,TValue>` | Tree-based sorted key-value pairs | `Add`, `TryGetValue`, `Remove` |
| `Queue<T>` | Generic FIFO | `Enqueue`, `Dequeue`, `TryDequeue` |
| `Stack<T>` | Generic LIFO | `Push`, `Pop`, `TryPop` |
| `HashSet<T>` | Unique values and set operations | `Add`, `Contains`, `UnionWith` |
| `LinkedList<T>` | Doubly linked nodes | `AddFirst`, `AddLast`, `AddAfter`, `Remove` |

## 28. Final recommendation

For most day-to-day .NET development:

- Use `List<T>` for a general collection of items.
- Use `Dictionary<TKey, TValue>` for lookup by a unique key.
- Use `HashSet<T>` to enforce uniqueness.
- Use `Queue<T>` for FIFO processing.
- Use `Stack<T>` for LIFO processing.
- Use `SortedDictionary<TKey, TValue>` when keys must remain sorted and updates are frequent.
- Use `LinkedList<T>` only when its node-based insertion/removal behavior is genuinely useful.

**Interview tip:** Do not only memorize definitions. Be ready to explain why you selected a collection in a real scenario, whether duplicates are allowed, whether ordering matters, how lookup works, and what happens when an item or key is missing.
