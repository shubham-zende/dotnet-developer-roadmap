# Encapsulation in C#

## 1. Definition

**Encapsulation** is an Object-Oriented Programming (OOP) principle that combines data (fields) and the methods or properties that operate on that data inside a class, while controlling how outside code can access or modify the data.

In simple words:

> Encapsulation = Data hiding + Controlled access to data.

For example, a bank account should not allow other code to change its balance to an invalid value directly. The account can expose a public property or methods that validate changes before updating the private balance field.

---

## 2. Why do we need encapsulation?

Without encapsulation, code from outside a class might change an object's data in an invalid or unexpected way.

Encapsulation helps us:

- Protect an object's internal state.
- Control how data is read and changed.
- Apply validation before accepting a new value.
- Keep implementation details hidden from other classes.
- Make code easier to maintain and update.
- Reduce accidental misuse of an object.

**Important:** `private` fields help prevent direct access, but encapsulation is not simply making every field private. It also means designing a controlled public interface for using the object's data.

---

## 3. How to achieve encapsulation in C#

A common approach is:

1. Create a class.
2. Declare the internal field as `private`.
3. Expose a `public` property or public methods when outside code needs access.
4. Add validation or business rules in the property's `set` accessor or in methods.
5. Allow only the operations that make sense for the object.

C# access modifiers commonly used in this context:

| Access modifier | Meaning |
|---|---|
| `private` | Accessible only within the declaring type. |
| `public` | Accessible wherever the containing type is accessible. |
| `protected` | Accessible within the declaring type and its derived types. |
| `internal` | Accessible within the same assembly. |
| `protected internal` | Accessible within the same assembly or from derived types. |
| `private protected` | Accessible within the declaring type or derived types in the same assembly. |

---

## 4. Fields and properties

### Field

A **field** stores data inside a class.

```csharp
private double balance;
```

Because `balance` is private, code outside the `BankAccount` class cannot access it directly.

### Property

A **property** provides a controlled way to read or assign a value.

```csharp
public double Balance
{
    get { return balance; }
    set { balance = value; }
}
```

- `get` runs when the property is read.
- `set` runs when a value is assigned to the property.
- Inside a `set` accessor, the keyword `value` represents the value being assigned.

Properties look like fields when used:

```csharp
account.Balance = 5000;           // Calls set
Console.WriteLine(account.Balance); // Calls get
```

However, a property is a member with accessors; it is not simply a public field.

---

## 5. Example: Bank account with validation

This example uses a private field and a public property. The property rejects negative balances.

```csharp
using System;

class BankAccount
{
    private double balance;

    public double Balance
    {
        get
        {
            return balance;
        }
        set
        {
            if (value >= 0)
            {
                balance = value;
            }
            else
            {
                Console.WriteLine("Balance cannot be negative!");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.Balance = 5000;
        Console.WriteLine(account.Balance);

        account.Balance = -1000;
        Console.WriteLine(account.Balance);
    }
}
```

### Output

```text
5000
Balance cannot be negative!
5000
```

### Explanation step by step

1. `BankAccount account = new BankAccount();` creates a new account. The `double` field initially has the default value `0`.
2. `account.Balance = 5000;` calls the property's `set` accessor. Since `5000 >= 0`, the private field is updated to `5000`.
3. `Console.WriteLine(account.Balance);` calls `get`, which returns `5000`.
4. `account.Balance = -1000;` calls `set`. The condition is false, so the field is not updated.
5. The next read returns the previous value, `5000`.

This direct assignment would not compile from `Program`:

```csharp
account.balance = 5000; // Error: balance is private
```

The field can only be accessed directly from within `BankAccount`.

> Learning note: In a real banking application, monetary amounts are usually represented with `decimal`, and deposits and withdrawals are better modeled as explicit methods with additional business rules. This example uses `double` to keep the property syntax simple.

---

## 6. Understanding the execution flow

When code assigns a value:

```csharp
account.Balance = 5000;
```

the flow is:

1. The caller accesses the public `Balance` property.
2. C# executes the property's `set` accessor.
3. The accessor checks the supplied `value`.
4. If the value is valid, it updates the private field `balance`.
5. If the value is invalid, the field remains unchanged.

When code reads a value:

```csharp
Console.WriteLine(account.Balance);
```

the `get` accessor returns the private field's value.

**Remember:** The public property is the controlled entry point; the private field stores the actual state.

---

## 7. What happens without encapsulation?

Consider a public field:

```csharp
class BankAccount
{
    public double balance;
}
```

Outside code can assign any value:

```csharp
BankAccount account = new BankAccount();

account.balance = 5000;
account.balance = -1000; // Accepted; no validation
```

The class has no control over the assignment. Making the field private and exposing a validating property prevents this kind of direct modification.

---

## 8. Auto-properties

C# supports **auto-implemented properties** when no custom logic is needed.

```csharp
public string Name { get; set; }
```

The compiler supplies hidden backing storage for the property.

An auto-property is convenient, but it does not validate values by itself. For validation, use a custom property:

```csharp
private int age;

public int Age
{
    get { return age; }
    set
    {
        if (value >= 0 && value <= 120)
        {
            age = value;
        }
    }
}
```

This example only updates `age` when the assigned value is between `0` and `120`, inclusive.

### Read-only and restricted properties

```csharp
public string Id { get; private set; }
```

- Other code can read `Id`.
- Only code within the containing class can set `Id`.

A get-only auto-property can be assigned during initialization or in a constructor:

```csharp
public string Country { get; }

public Person(string country)
{
    Country = country;
}
```

---

## 9. Encapsulation using methods

Encapsulation can also be achieved with public methods that control access to private fields.

```csharp
using System;

class BankAccount
{
    private decimal balance;

    public decimal GetBalance()
    {
        return balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive.");
        }
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        account.Deposit(1000);
        Console.WriteLine(account.GetBalance());

        account.Deposit(-200);
        Console.WriteLine(account.GetBalance());
    }
}
```

### Output

```text
1000
Deposit amount must be positive.
1000
```

The caller cannot set `balance` directly. It must use the public operations provided by the class.

In real applications, a method such as `Withdraw` would also check that the amount is positive and that sufficient funds are available.

---

## 10. Encapsulation vs. data hiding

These concepts are related, but they are not exactly the same.

| Concept | Meaning |
|---|---|
| Encapsulation | Bundles state and behavior together and provides a controlled interface. |
| Data hiding | Restricts direct access to internal implementation details, often using access modifiers such as `private`. |

**Memory tip:** Data hiding is one technique used to support encapsulation.

---

## 11. Encapsulation vs. abstraction

| Encapsulation | Abstraction |
|---|---|
| Controls access to data and object state. | Exposes essential behavior while hiding unnecessary implementation details. |
| Commonly uses private fields and public properties or methods. | Commonly uses clear public APIs, interfaces, and abstract classes. |
| Example: a property rejects a negative age. | Example: a caller uses `Car.Start()` without needing to know how the engine starts. |

Both are important OOP principles, but they solve different problems.

---

## 12. Advantages of encapsulation

1. **Data protection:** Prevents outside code from directly modifying private fields.
2. **Validation:** Allows invalid values to be rejected.
3. **Maintainability:** Internal implementation can change while the public interface stays consistent.
4. **Control:** The class decides which operations are available.
5. **Reliability:** Helps preserve valid object state.
6. **Reduced coupling:** Other classes depend on the public interface rather than internal storage details.

Encapsulation does not automatically guarantee security or correctness. The public interface must still be designed and validated properly.

---

## 13. Common mistakes

- Declaring every field `public` and allowing uncontrolled modification.
- Assuming a property automatically validates values.
- Using `get` and `set` without understanding when they execute.
- Thinking encapsulation means making all members private.
- Confusing encapsulation with inheritance or polymorphism.
- Forgetting that a public property can still expose data in an unsafe or overly permissive way.
- Assuming that `private set` makes a property writeable from anywhere; it restricts assignment to the containing type.

---

## 14. Interview questions and short answers

### Q1. What is encapsulation in C#?

Encapsulation combines data and related behavior inside a class and controls access to the internal state.

### Q2. How do you achieve encapsulation in C#?

Typically, declare fields as `private` and expose controlled access through public properties or methods.

### Q3. What is the purpose of a private field?

It prevents code outside the declaring type from accessing the field directly.

### Q4. What is a property in C#?

A property provides access to data through `get` and/or `set` accessors and can contain validation logic.

### Q5. What is the difference between a field and a property?

A field stores data directly. A property defines accessors that control how a value is read or assigned.

### Q6. Is encapsulation possible without properties?

Yes. Public methods can provide controlled access to private fields.

### Q7. What is an auto-property?

An auto-property uses `{ get; set; }` or related accessor syntax without explicitly declaring a backing field.

### Q8. Why is encapsulation useful?

It protects internal state, supports validation, reduces accidental misuse, and makes code easier to maintain.

### Q9. Is encapsulation the same as data hiding?

No. Data hiding restricts access to internal details; encapsulation bundles state and behavior and provides a controlled interface.

### Q10. Can a property be read-only?

Yes. For example, `public string Id { get; private set; }` allows outside code to read the property but restricts setting it to the containing class.

---

## 15. Quick revision notes

- **Definition:** Bundling data and behavior while controlling access to the object's state.
- **Main technique:** Private fields + public properties or methods.
- **`private`:** Restricts direct access to the declaring type.
- **`public`:** Makes a member accessible through the public interface.
- **`get`:** Reads a property's value.
- **`set`:** Assigns a property's value; `value` contains the incoming value.
- **Validation:** Put rules in a custom setter or a suitable method.
- **Benefit:** Controlled access, valid state, maintainability, and reduced accidental misuse.
- **Real-life example:** A bank account accepts valid deposits and rejects invalid amounts.

### One-line memory formula

**Class + private state + controlled public interface = Encapsulation**

---

## 16. Practice task

Create a `Student` class with:

1. A private field called `_marks`.
2. A public property called `Marks`.
3. Validation that accepts marks only from `0` to `100`.
4. A `Main` method that assigns `85`, displays the marks, then tries to assign `150`.
5. Verify that the invalid assignment does not change the stored marks.

**Expected behavior:** The first assignment succeeds; the second is rejected; the stored marks remain `85`.