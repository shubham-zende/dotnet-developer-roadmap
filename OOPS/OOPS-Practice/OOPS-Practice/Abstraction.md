# Abstraction in C#

## 1. What is Abstraction?

**Abstraction is an Object-Oriented Programming (OOP) principle that hides implementation details and shows only the essential functionality to the user.**

In simple words:

- **What to do:** The functionality that is available to the user.
- **How to do it:** The internal implementation that can be hidden.

### Memory trick

**Abstraction = Show what an object does, hide how it does it.**

---

## 2. Real-life example

### Example: Driving a car

When you drive a car, you use the steering wheel, accelerator, and brake.

You do not need to know every detail of how the engine, fuel injection, or braking system works internally.

- You know **what** action to perform.
- The car handles **how** that action is performed internally.

This is the basic idea of abstraction.

### Example: ATM

You select “Withdraw Cash” and enter an amount. The ATM performs several internal operations, such as checking your account and processing the transaction. You use the available operation without needing to know all the internal implementation details.

---

## 3. How do we achieve abstraction in C#?

C# commonly uses these two features to implement abstraction:

1. **Abstract classes**
2. **Interfaces**

An abstract class is useful when related classes share a common base and may share some implementation.

An interface is useful when different classes must provide a particular set of capabilities or follow a contract.

---

## 4. Abstraction using an abstract class

An **abstract class** is a class that cannot be instantiated directly. It can contain abstract methods as well as methods with implementations.

An **abstract method** is declared without a method body. A concrete derived class must implement inherited abstract methods.

### Example: Animal sounds

```csharp
using System;

abstract class Animal
{
    public abstract void Sound();
}

class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Cat meows");
    }
}

class Program
{
    static void Main()
    {
        Animal animal1 = new Dog();
        animal1.Sound();

        Animal animal2 = new Cat();
        animal2.Sound();
    }
}
```

### Output

```text
Dog barks
Cat meows
```

### Explanation step by step

1. `abstract class Animal` declares an abstract base class.
2. `public abstract void Sound();` declares a method without an implementation.
3. `Dog : Animal` means `Dog` inherits from `Animal`.
4. `override` provides the implementation of the inherited abstract method.
5. `Animal animal1 = new Dog();` creates a `Dog` object and stores its reference in an `Animal` variable.
6. When `animal1.Sound()` is called, the `Dog` implementation runs.
7. Similarly, `animal2.Sound()` runs the `Cat` implementation.

The base class defines **what operation is available** (`Sound`), while the derived classes define **how that operation works** for each animal.

### Important rules for abstract classes

- You cannot create an object directly from an abstract class.
- An abstract class can contain abstract methods and normal methods.
- An abstract class can contain fields, properties, constructors, and other members.
- An abstract method has no method body.
- A non-abstract derived class must implement all inherited abstract members unless they have already been implemented in an intermediate class.
- The `override` keyword is used to implement an inherited abstract method.

For example, this is not allowed:

```csharp
Animal animal = new Animal(); // Compilation error
```

But this is allowed:

```csharp
Animal animal = new Dog();
animal.Sound();
```

---

## 5. Abstract class with both abstract and normal methods

An abstract class does not need to contain only abstract methods. It can also provide common behavior.

```csharp
using System;

abstract class Vehicle
{
    public void Start()
    {
        Console.WriteLine("Vehicle is starting");
    }

    public abstract void Drive();
}

class Car : Vehicle
{
    public override void Drive()
    {
        Console.WriteLine("Car is moving");
    }
}

class Program
{
    static void Main()
    {
        Car car = new Car();

        car.Start();
        car.Drive();
    }
}
```

### Output

```text
Vehicle is starting
Car is moving
```

### Explanation

- `Start()` is a normal method with an implementation in the base class.
- `Drive()` is abstract, so the concrete derived class must provide its implementation.
- `Car` reuses the common `Start()` method and implements its own `Drive()` behavior.

**When to use this:** Use an abstract class when related classes need common state or shared functionality but some behavior must be implemented differently by each derived class.

---

## 6. Abstraction using an interface

An **interface** defines a contract that a class or struct can implement.

For example, an interface can specify that a type must provide a `Pay()` method. Different payment types can implement that method differently.

### Example: Payment methods

```csharp
using System;

interface IPayment
{
    void Pay();
}

class CreditCardPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Payment made using credit card");
    }
}

class UpiPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Payment made using UPI");
    }
}

class Program
{
    static void Main()
    {
        IPayment payment1 = new CreditCardPayment();
        payment1.Pay();

        IPayment payment2 = new UpiPayment();
        payment2.Pay();
    }
}
```

### Output

```text
Payment made using credit card
Payment made using UPI
```

### Explanation

1. `IPayment` defines the `Pay()` contract.
2. `CreditCardPayment` implements that contract using credit-card behavior.
3. `UpiPayment` implements the same contract using UPI behavior.
4. The `Program` code calls `Pay()` through an `IPayment` reference without needing to depend on each implementation's internal details.

In this example, the interface has no method body for `Pay()`, and both implementing classes provide their own implementations.

**Note:** Modern C# also supports some interface members with default implementations. For beginner examples, interfaces are often shown as contracts that implementing types must fulfill.

---

## 7. Abstract class vs. interface

| Abstract class | Interface |
|---|---|
| Declared using the `abstract class` syntax. | Declared using the `interface` keyword. |
| Can contain fields and constructors. | Cannot contain instance fields or instance constructors. |
| Can contain abstract methods and methods with implementations. | Primarily defines a contract; modern C# also supports default implementations for certain members. |
| A class can inherit from only one class. | A class can implement multiple interfaces. |
| Useful for related classes that share state or common behavior. | Useful for defining capabilities that different types can share. |

### Memory trick

- **Abstract class:** A common base with shared code and some required behavior.
- **Interface:** A contract that says which capabilities a type provides.

---

## 8. Abstraction vs. encapsulation

These are two different OOP principles.

| Abstraction | Encapsulation |
|---|---|
| Hides implementation complexity. | Controls access to an object's internal state. |
| Focuses on what an object does. | Focuses on protecting and managing data. |
| Commonly implemented with abstract classes and interfaces. | Commonly implemented with private fields and controlled properties or methods. |
| Example: Calling `payment.Pay()` without knowing its internal steps. | Example: A bank account validates changes to its private balance. |

### Memory trick

**Abstraction = Hide complexity.**

**Encapsulation = Control access to data.**

A class can use both principles at the same time.

---

## 9. Advantages of abstraction

1. **Reduces complexity:** Users work with a clear set of operations.
2. **Hides implementation details:** Callers do not need to understand every internal step.
3. **Improves maintainability:** Internal implementations can change without necessarily changing the public contract.
4. **Supports flexibility:** Different classes can provide different implementations of a common operation.
5. **Supports polymorphism:** A base-class or interface reference can call the implementation supplied by the actual object.
6. **Improves code organization:** Common contracts make larger applications easier to structure.

---

## 10. Common mistakes

- Trying to instantiate an abstract class directly.
- Declaring an abstract method with a method body.
- Forgetting to implement an inherited abstract method in a concrete class.
- Forgetting `override` when implementing an inherited abstract method.
- Thinking abstraction and encapsulation mean the same thing.
- Assuming every interface member must always lack an implementation; modern C# supports default interface implementations for certain members.
- Using an abstract class when an interface would better express a capability shared by otherwise unrelated types.

---

## 11. Interview questions and short answers

### Q1. What is abstraction in C#?

Abstraction hides implementation details and exposes essential functionality.

### Q2. How can we achieve abstraction in C#?

Commonly through abstract classes and interfaces.

### Q3. Can we create an object of an abstract class?

No. An abstract class cannot be instantiated directly, but a variable of its type can refer to an object of a concrete derived class.

### Q4. Can an abstract class contain a normal method?

Yes. It can contain both abstract methods and methods with implementations.

### Q5. What is an abstract method?

An abstract method is declared without an implementation in the abstract class and must be implemented by a concrete derived class, unless an intermediate class implements it.

### Q6. What is an interface?

An interface defines a contract that implementing classes or structs agree to fulfill.

### Q7. What is the difference between abstraction and encapsulation?

Abstraction hides implementation complexity, whereas encapsulation controls access to internal data and state.

### Q8. Can a class implement multiple interfaces?

Yes. A class can implement multiple interfaces, although it can inherit from only one class.

### Q9. Why do we use abstraction?

To reduce complexity, define clear contracts, and allow different implementations behind a common interface.

### Q10. What is the role of `override` in an abstract class example?

`override` provides the implementation of an inherited abstract method or replaces an inherited virtual method implementation.

---

## 12. Quick revision notes

- **Definition:** Hide implementation details and show essential functionality.
- **Main C# techniques:** Abstract classes and interfaces.
- **Abstract class:** Cannot be instantiated directly; can contain implemented and abstract members.
- **Abstract method:** Declared without a method body.
- **Override:** Provides an implementation for an inherited abstract method.
- **Interface:** Defines a contract that implementing types follow.
- **Benefit:** Less complexity, clearer contracts, and flexible implementations.
- **Real-life example:** Use a car's controls without needing to understand its internal mechanisms.

### One-line memory formula

**Abstraction = What to do; implementation = How to do it.**

---

## 13. Practice tasks

### Task 1: Shapes

Create an abstract class `Shape` with an abstract method `CalculateArea()`.

Create `Circle` and `Rectangle` classes that inherit from `Shape` and implement `CalculateArea()`.

**Goal:** Understand how different derived classes implement the same abstract method differently.

### Task 2: Notifications

Create an interface `INotification` with a method `Send()`.

Implement it in `EmailNotification` and `SmsNotification`.

**Goal:** Understand how different classes can implement the same contract.

### Task 3: Revision

Explain these questions in your own words:

1. What is abstraction?
2. Why can't we instantiate an abstract class?
3. What is the difference between an abstract class and an interface?
4. How is abstraction different from encapsulation?
5. How does abstraction help support polymorphism?