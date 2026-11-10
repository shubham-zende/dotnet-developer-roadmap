# C# `in`, `ref`, and `out` Parameters

## Quick comparison

| Keyword | Purpose | Must be initialized before call? | Can method change it? | Must assign inside method? |
|---|---|---:|---:|---:|
| `in` | Pass by reference, read-only inside the method | Yes | No | No |
| `ref` | Pass by reference; read and update the caller's variable | Yes | Yes | No |
| `out` | Pass a variable to receive an output value | No | Yes | Yes, before the method returns |

## 1. `in` parameter

- Passes an argument by reference.
- The caller must initialize the variable before passing it.
- The method can read it but cannot assign a new value to that parameter.

```csharp
static void Display(in int number)
{
    Console.WriteLine(number);
    // number = 20; // Compile-time error
}

int value = 10;
Display(value);
```

**Use it when:** You want to avoid copying a large value type while ensuring the method does not modify it.

## 2. `ref` parameter

- Passes the caller's variable by reference.
- The variable must be initialized before the method call.
- The method can read and modify the variable.
- Changes are visible to the caller.

```csharp
static void Update(ref int number)
{
    number = 20;
}

int value = 10;
Update(ref value);
Console.WriteLine(value); // 20
```

**Use it when:** A method needs to update an existing variable supplied by the caller.

## 3. `out` parameter

- Passes a variable by reference to receive a result.
- The caller does not need to initialize the variable first.
- The method must assign a value to every `out` parameter before it returns.
- The caller can use the variable after the method call.

```csharp
static void GetValues(out int number)
{
    number = 100; // Required assignment
}

int value;
GetValues(out value);
Console.WriteLine(value); // 100
```

**Use it when:** A method needs to return additional values through parameters, such as `int.TryParse`.

```csharp
bool success = int.TryParse("123", out int result);
```

## Important rules

1. Use the keyword at both the method declaration and the call site.
2. `ref` and `out` arguments must match the parameter's type.
3. A method cannot overload another method based only on `ref`, `out`, and `in` differences in the same parameter position.
4. `in` is read-only through that parameter; it does not make the referenced object deeply immutable.
5. `ref` and `out` cannot be used interchangeably at the call site.
6. `in`, `ref`, and `out` parameters cannot be used with `async` methods in the usual way because they are by-reference parameters.

---

# Interview Questions and Answers

### 1. What is the difference between `ref`, `out`, and `in`?

**Answer:** All three pass an argument by reference. `ref` allows reading and modifying an initialized variable. `out` is used to return a value and must be assigned inside the method. `in` requires an initialized variable but prevents reassignment through that parameter.

### 2. Is initialization required for `ref`?

**Answer:** Yes. The variable must have a value before it is passed using `ref`.

### 3. Is initialization required for `out`?

**Answer:** No. The caller can pass an uninitialized local variable, but the method must assign it before returning.

### 4. Is initialization required for `in`?

**Answer:** Yes. The argument must already have a value.

### 5. Can we modify an `in` parameter?

**Answer:** We cannot assign a new value to the `in` parameter itself. However, if it refers to an object, the object's mutable members may still be changed.

### 6. What happens if we do not assign an `out` parameter?

**Answer:** The code will fail to compile because every `out` parameter must be definitely assigned before the method returns.

### 7. Can we use multiple `out` parameters?

**Answer:** Yes. A method can return multiple values using multiple `out` parameters.

```csharp
static void GetNameAndAge(out string name, out int age)
{
    name = "Amit";
    age = 25;
}
```

### 8. What is a real-world use of `out`?

**Answer:** `int.TryParse()` uses an `out` parameter to provide the parsed number while returning a Boolean that indicates whether parsing succeeded.

### 9. What is a real-world use of `ref`?

**Answer:** A method that updates a caller's existing value, such as adjusting a running total, can use `ref`.

### 10. Why would you use `in`?

**Answer:** It can avoid copying large structs while communicating that the method should not reassign the input parameter.

### 11. Can we pass a property with `ref` or `out`?

**Answer:** Generally, no. A property is accessed through getter/setter methods rather than being a variable that can be passed by reference. Use a local variable or another suitable design.

### 12. Can we overload methods using only `ref` and `out`?

**Answer:** No. You cannot create overloads that differ only by changing `ref` to `out` for the same parameter position.

### 13. What is the difference between `return` and `out`?

**Answer:** `return` sends back the method's return value. `out` allows the method to provide additional values through arguments. A method can use both.

### 14. What happens to a `ref` variable if the method changes it?

**Answer:** The caller sees the changed value because the method operates on the caller's variable by reference.

### 15. Can `ref`, `out`, or `in` parameters be used in an `async` method?

**Answer:** No. C# does not allow `async` methods to have `ref`, `out`, or `in` parameters.

---

## Quick interview revision

- **`in` = input, read-only parameter**
- **`ref` = input + update**
- **`out` = output; method must assign it**

Remember: `in` and `ref` require an initialized argument; `out` does not.