## What is Inheritance?

**Inheritance** is an OOP concept where a child class (derived class) gets accessible members from a parent class (base class).

It helps with **code reuse** and creating relationships between classes.

### Basic syntax

```csharp
class Parent
{
    public void Show()
    {
        Console.WriteLine("This is the parent class.");
    }
}

class Child : Parent
{
}

// Usage
Child obj = new Child();
obj.Show(); // This is the parent class.
```

`Child : Parent` means that `Child` inherits from `Parent`.

> **Remember:** A derived class can access `public` and `protected` members of its base class, subject to normal C# rules. It cannot directly access the base class's `private` members.

---

## 1. Single Inheritance

**Meaning:** One child class inherits from one parent class.

```csharp
class Animal
{
    public void Eat()
    {
        Console.WriteLine("Animal is eating.");
    }
}

class Dog : Animal
{
    public void Bark()
    {
        Console.WriteLine("Dog is barking.");
    }
}

// Usage
Dog dog = new Dog();
dog.Eat();  // Inherited method
dog.Bark(); // Dog's own method
```

**Easy way to remember:** One parent → one child.

---

## 2. Multilevel Inheritance

**Meaning:** A class inherits from a child class, forming a chain of inheritance.

```csharp
class Animal
{
    public void Eat() => Console.WriteLine("Eating");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking");
}

class Puppy : Dog
{
    public void Weep() => Console.WriteLine("Weeping");
}

// Usage
Puppy puppy = new Puppy();
puppy.Eat();  // From Animal
puppy.Bark(); // From Dog
puppy.Weep(); // From Puppy
```

**Easy way to remember:** Grandparent → Parent → Child.

---

## 3. Hierarchical Inheritance

**Meaning:** Multiple child classes inherit from the same parent class.

```csharp
class Animal
{
    public void Eat() => Console.WriteLine("Eating");
}

class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking");
}

class Cat : Animal
{
    public void Meow() => Console.WriteLine("Meowing");
}

// Usage
Dog dog = new Dog();
dog.Eat();
dog.Bark();

Cat cat = new Cat();
cat.Eat();
cat.Meow();
```

**Easy way to remember:** One parent → multiple children.

---

## 4. Multiple Inheritance

**Meaning:** One child class inherits from more than one parent class.

**Important in C#:** C# classes do **not** support multiple inheritance from classes. A class cannot inherit from two classes at the same time.

This is invalid:

```csharp
// Not valid C#
class Child : ParentA, ParentB
{
}
```

However, C# supports implementing multiple **interfaces**:

```csharp
interface IPrinter
{
    void Print();
}

interface IScanner
{
    void Scan();
}

class AllInOneMachine : IPrinter, IScanner
{
    public void Print() => Console.WriteLine("Printing...");
    public void Scan() => Console.WriteLine("Scanning...");
}

// Usage
AllInOneMachine machine = new AllInOneMachine();
machine.Print();
machine.Scan();
```

**Easy way to remember:** Multiple class inheritance is not supported; multiple interfaces are supported.

---

## 5. Hybrid Inheritance

**Meaning:** A combination of two or more inheritance patterns, such as hierarchical and multilevel inheritance.

C# does not support every hybrid pattern through classes alone if it requires a class to inherit from multiple classes. Interfaces can be used to achieve similar designs.

```csharp
interface IRunner
{
    void Run();
}

class Animal
{
    public void Eat() => Console.WriteLine("Eating");
}

class Dog : Animal, IRunner
{
    public void Run() => Console.WriteLine("Running");
}

class Puppy : Dog
{
    public void Play() => Console.WriteLine("Playing");
}

// Usage
Puppy puppy = new Puppy();
puppy.Eat();  // From Animal
puppy.Run();  // Implemented from IRunner through Dog
puppy.Play(); // From Puppy
```

**Easy way to remember:** Hybrid = combination of inheritance patterns.

---

## Quick Comparison

| Type | Meaning | Supported in C#? |
|---|---|---|
| Single | One child inherits from one parent | Yes |
| Multilevel | Inheritance in a chain | Yes |
| Hierarchical | Multiple children share one parent | Yes |
| Multiple (classes) | One class inherits from multiple classes | No |
| Multiple (interfaces) | One class implements multiple interfaces | Yes |
| Hybrid | Combination of inheritance patterns | Depends on the design; interfaces can help |

---

## Useful Interview Notes

- Use `:` to inherit from a base class or implement interfaces.
- C# supports inheritance from **one base class** at a time.
- A class can implement **multiple interfaces**.
- `public` members are accessible through derived-class objects, subject to the member's accessibility.
- `protected` members can be accessed in the derived class, but not directly through an ordinary object from outside the class.
- A base class can mark a method `virtual`, and a derived class can customize it with `override`.
- Use inheritance when there is a genuine **“is-a”** relationship, such as `Dog` is an `Animal`.

### Small `virtual` and `override` example

```csharp
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks.");
    }
}

// Usage
Animal animal = new Dog();
animal.Sound(); // Dog barks.
```

`virtual` allows a method to be overridden. `override` provides the derived class's implementation.

---

## Summary

Inheritance lets classes reuse and extend existing code. Learn **single, multilevel, and hierarchical inheritance** first. For multiple inheritance, remember that C# does not allow inheriting from multiple classes, but it does allow implementing multiple interfaces.