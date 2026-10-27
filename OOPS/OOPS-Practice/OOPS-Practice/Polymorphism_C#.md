## 1. What is Polymorphism?

**Polymorphism** means “many forms.” In object-oriented programming (OOP), it allows the same method name or base-class reference to behave differently in different situations.

- **Poly** = many
- **Morphism** = forms

In C#, polymorphism is commonly explained through two types:

1. **Compile-time / Static polymorphism** — commonly achieved through method overloading.
2. **Run-time polymorphism** — commonly achieved through method overriding.

> Note: These are the two main forms usually taught in C# OOP fundamentals. C# also supports other polymorphic features, such as interface-based polymorphism.

---

## 2. Compile-Time / Dynamic Polymorphism (Method Overloading)

Compile-time polymorphism is resolved by the compiler based on the method call and the arguments supplied.

**Method overloading** means defining multiple methods with the same name in the same class, but with different parameter lists.

Overloaded methods can differ by:
- Number of parameters
- Parameter types
- Order of parameter types

### Example

```csharp
using System;

public class Calculator
{
    public void Display(int a)
    {
        Console.WriteLine("Integer parameter: " + a);
    }

    public void Display(char c)
    {
        Console.WriteLine("Character parameter: " + c);
    }

    public void Display(int a, char b)
    {
        Console.WriteLine("Integer and character: " + a + " " + b);
    }

    public void Display(char b, int a)
    {
        Console.WriteLine("Character and integer: " + b + " " + a);
    }
}

public class Program
{
    public static void Main()
    {
        Calculator calculator = new Calculator();

        calculator.Display(10);
        calculator.Display('A');
        calculator.Display(10, 'B');
        calculator.Display('C', 20);
    }
}
```

### Important points

- The method name is the same: `Display`.
- The parameter lists are different, so the compiler can select the appropriate overload.
- **Changing only the return type is not enough** to create a valid overload.
- Overloading is not the same as overriding: overloading usually occurs within the same class, while overriding involves an inherited method and a derived class.

---

## 3. Run-Time Polymorphism (Method Overriding)

Run-time polymorphism occurs when a call to an overridable instance method is dispatched according to the **actual object type at run time**.

**Method overriding** happens when a derived class provides its own implementation of a virtual or abstract method inherited from a base class.

### Keywords used

- `virtual` — marks a base-class method as eligible for overriding.
- `override` — supplies the derived-class implementation of an inherited virtual or abstract method.
- `abstract` — declares a member that has no implementation in the base class and must be implemented by a concrete derived class.

### Example using `virtual` and `override`

```csharp
using System;

public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Animal makes a sound.");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks.");
    }
}

public class Program
{
    public static void Main()
    {
        Animal animal = new Dog();
        animal.MakeSound(); // Output: Dog barks.
    }
}
```

### How it works

- `Animal animal` is the **reference type**.
- `new Dog()` creates a **Dog object**.
- `MakeSound()` is overridden in `Dog`.
- Because the method is virtual and overridden, the implementation selected at run time is `Dog.MakeSound()`.

This is the key idea: a base-class reference can refer to a derived-class object, and an overridden method can execute the derived class's implementation.

---

## 4. Abstract Classes and Abstract Methods

An **abstract class** is a class that cannot be instantiated directly. It is commonly used as a base class that defines a shared contract for derived classes.

An abstract class can contain:
- Abstract methods (declared without a method body)
- Concrete methods (methods with an implementation)
- Fields, properties, constructors, and other class members

A concrete derived class must implement all inherited abstract members unless the derived class is also declared `abstract`.

### Example: Bank Account

```csharp
using System;

public abstract class Account
{
    public abstract void AccountDetails();
    public abstract void Deposit();
    public abstract void Withdrawal();
    public abstract void ShowBalance();

    public void BankDetails()
    {
        Console.WriteLine("Bank details.");
    }
}

public class SavingAccount : Account
{
    public override void AccountDetails()
    {
        Console.WriteLine("Savings account details.");
    }

    public override void Deposit()
    {
        Console.WriteLine("Depositing into the savings account.");
    }

    public override void Withdrawal()
    {
        Console.WriteLine("Withdrawing from the savings account.");
    }

    public override void ShowBalance()
    {
        Console.WriteLine("Showing savings account balance.");
    }
}

public class Program
{
    public static void Main()
    {
        Account account = new SavingAccount();

        account.BankDetails();    // Inherited concrete method
        account.AccountDetails(); // Overridden implementation
        account.Deposit();
        account.Withdrawal();
        account.ShowBalance();
    }
}
```

### Explanation

- `Account` is abstract, so `new Account()` is not allowed.
- The abstract methods define what a concrete account class must implement.
- `SavingAccount` overrides each abstract method.
- `BankDetails()` is a concrete method, so `SavingAccount` inherits it without needing to override it.
- `Account account = new SavingAccount();` demonstrates polymorphism through a base-class reference.

**Spelling note:** Use `Deposit`, `Withdrawal`, and `AccountDetails` for clearer, conventional method names.

---

## 5. Method Overloading vs. Method Overriding

| Feature | Method Overloading | Method Overriding |
|---|---|---|
| Polymorphism type | Compile-time | Run-time |
| Main idea | Same method name, different parameter lists | Derived class replaces inherited virtual/abstract implementation |
| Inheritance required? | No | Yes |
| Parameter list | Must differ | Must match the overridden method's signature |
| Common keywords | No special keyword required | `virtual` in base class and `override` in derived class, or an abstract base member with `override` |
| Method selection | Based on compile-time overload resolution | Based on the actual object type at run time for virtual dispatch |

---

## 6. Quick Revision Notes

- **Polymorphism** means one name or reference can represent many forms.
- **Overloading**: same method name, different parameter lists.
- **Overriding**: a derived class provides a new implementation of an inherited virtual or abstract method.
- `virtual` allows a base-class method to be overridden.
- `override` implements or replaces the inherited virtual/abstract method.
- `abstract class` cannot be instantiated directly.
- `abstract method` has no implementation in the abstract base class and must be overridden by a concrete derived class.
- A base-class reference can hold a derived-class object, for example: `Account account = new SavingAccount();`.
- An inherited concrete method does not need to be overridden unless the derived class needs different behavior.

## 7. Interview Answer

**What is polymorphism in C#?**

Polymorphism is an OOP concept that allows the same method name or base-class reference to represent different behaviors. In C#, method overloading is a common example of compile-time polymorphism, while method overriding using `virtual` and `override` is a common example of run-time polymorphism.
"""
