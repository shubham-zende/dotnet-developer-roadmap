
## 1. Basic Questions

### Q1. What is file handling in C#?
File handling means creating, reading, writing, appending, and deleting files. It uses the `System.IO` namespace.

### Q2. Which namespace is used for file handling?
`System.IO`

```csharp
using System.IO;
```

### Q3. What is the difference between `File` and `FileInfo`?
- `File`: Uses static methods; good for simple file operations.
- `FileInfo`: Uses an object; useful when working with one file repeatedly.

### Q4. How do you create a file?
```csharp
File.Create("data.txt").Dispose();
```
`Dispose()` closes the file stream. Creating an existing file clears its contents.

### Q5. How do you write data to a file?
```csharp
File.WriteAllText("data.txt", "Hello C#");
```
Creates the file or overwrites its existing content.

### Q6. How do you read a file?
```csharp
string data = File.ReadAllText("data.txt");
Console.WriteLine(data);
```

### Q7. Difference between `WriteAllText()` and `AppendAllText()`?
- `WriteAllText()`: Replaces existing content.
- `AppendAllText()`: Adds content at the end.

```csharp
File.WriteAllText("data.txt", "First line");
File.AppendAllText("data.txt", "\nSecond line");
```

### Q8. How do you check whether a file exists?
```csharp
if (File.Exists("data.txt"))
    Console.WriteLine("File exists");
```

### Q9. How do you delete a file?
```csharp
File.Delete("data.txt");
```

### Q10. How do you read a file line by line into an array?
```csharp
string[] lines = File.ReadAllLines("data.txt");
foreach (string line in lines)
    Console.WriteLine(line);
```

## 2. Intermediate Questions

### Q11. Difference between `ReadAllText()` and `ReadAllLines()`?
- `ReadAllText()`: Returns the whole file as one string.
- `ReadAllLines()`: Returns an array of lines.

### Q12. What is `StreamReader`?
It reads text from a file, often one line at a time.

```csharp
using StreamReader reader = new StreamReader("data.txt");
string? line;
while ((line = reader.ReadLine()) != null)
    Console.WriteLine(line);
```

### Q13. What is `StreamWriter`?
It writes text to a file.

```csharp
using StreamWriter writer = new StreamWriter("data.txt");
writer.WriteLine("Hello C#");
```
To append, use `new StreamWriter("data.txt", append: true)`.

### Q14. Difference between `StreamReader` and `StreamWriter`?
- `StreamReader`: Reads text.
- `StreamWriter`: Writes text.

### Q15. What is `FileStream`?
It reads or writes a file as bytes. It is useful for binary data and low-level file operations.

### Q16. Difference between `FileStream` and `StreamWriter`?
- `FileStream`: Works with bytes.
- `StreamWriter`: Writes character/text data.

### Q17. Why use `using` in file handling?
It automatically disposes the reader, writer, or stream and releases resources.

### Q18. Difference between `File` and `FileStream`?
- `File`: Provides simple static methods such as `ReadAllText()`.
- `FileStream`: Gives stream-based access to file bytes.

### Q19. What is the `Directory` class?
It provides static methods to create, check, and delete directories.

```csharp
Directory.CreateDirectory("Reports");
bool exists = Directory.Exists("Reports");
```

### Q20. Difference between `Directory` and `DirectoryInfo`?
- `Directory`: Uses static methods.
- `DirectoryInfo`: Uses an object for a specific directory.

## 3. File Modes and Exception Handling

### Q21. What is `FileMode`?
It specifies how a file should be opened or created.

- `Open`: Opens an existing file.
- `Create`: Creates a file or clears an existing file.
- `OpenOrCreate`: Opens or creates a file.
- `CreateNew`: Creates a new file; fails if it exists.
- `Append`: Writes at the end of a file.
- `Truncate`: Clears an existing file.

### Q22. Difference between `FileMode.Create` and `FileMode.Open`?
- `Create`: Creates a file or clears its existing content.
- `Open`: Opens an existing file and preserves its content.

### Q23. How do you handle file exceptions?
Use `try-catch` to handle errors such as missing files or access problems.

```csharp
try
{
    string data = File.ReadAllText("data.txt");
}
catch (IOException ex)
{
    Console.WriteLine(ex.Message);
}
```

### Q24. What happens if you read a file that does not exist?
Methods such as `ReadAllText()` normally throw `FileNotFoundException`.

### Q25. Difference between `FileNotFoundException` and `DirectoryNotFoundException`?
- `FileNotFoundException`: The file is missing.
- `DirectoryNotFoundException`: Part of the directory path is missing.

### Q26. How do you copy or move a file?
```csharp
File.Copy("source.txt", "backup.txt");
File.Move("backup.txt", "archive.txt");
```

### Q27. How do you get file information?
Use `FileInfo`.

```csharp
FileInfo info = new FileInfo("data.txt");
Console.WriteLine(info.Name);
Console.WriteLine(info.Extension);
Console.WriteLine(info.Length);
```

## 4. Advanced Questions

### Q28. How do you read a large file efficiently?
Use `File.ReadLines()` or `StreamReader` to process one line at a time.

```csharp
foreach (string line in File.ReadLines("large.txt"))
    Console.WriteLine(line);
```

### Q29. What is asynchronous file handling?
It lets you await file operations without synchronously blocking the calling thread.

```csharp
string data = await File.ReadAllTextAsync("data.txt");
```

### Q30. Difference between synchronous and asynchronous file operations?
- **Synchronous:** The call waits until the operation finishes.
- **Asynchronous:** The operation can be awaited while other work continues.

### Q31. Difference between `ReadAllTextAsync()` and `ReadLineAsync()`?
- `ReadAllTextAsync()`: Reads the entire file as one string.
- `ReadLineAsync()`: Reads one line asynchronously.

### Q32. Can multiple users access the same file?
Yes, depending on the file's sharing settings. Exclusive access can prevent other processes from opening it.

### Q33. What is file locking?
It controls access to a file to help prevent conflicting operations. Sharing settings do not solve every concurrency problem.

### Q34. Difference between `AppendAllText()` and `StreamWriter` in append mode?
Both append text. `AppendAllText()` is simple for one operation; `StreamWriter` is useful for writing multiple lines.

### Q35. How do you combine file paths safely?
Use `Path.Combine()` instead of joining path strings manually.

```csharp
string path = Path.Combine(@"C:\Reports", "report.txt");
```

## 5. ASP.NET Core File Handling

### Q36. How do you upload a file in ASP.NET Core Web API?
Use `IFormFile`, validate the file, and save it to an appropriate location.

```csharp
[HttpPost("upload")]
public async Task<IActionResult> Upload(IFormFile file)
{
    if (file == null || file.Length == 0)
        return BadRequest("Select a file.");

    string folder = Path.Combine(
        Directory.GetCurrentDirectory(), "Uploads");

    Directory.CreateDirectory(folder);

    string path = Path.Combine(folder, Path.GetRandomFileName());

    await using var stream = new FileStream(
        path, FileMode.CreateNew, FileAccess.Write);

    await file.CopyToAsync(stream);
    return Ok("File uploaded.");
}
```
For production, validate file size and content, restrict file types, and protect uploaded files.

### Q37. How do you download a file from an API?
Return a file result using `PhysicalFile()` or `File()`.

```csharp
return PhysicalFile(path, "application/pdf", "report.pdf");
```

### Q38. Where should uploaded files be stored?
- Local storage: Suitable for some small or single-server applications.
- Cloud storage: Often better for scalable applications.
- Database: Useful for some cases, but not always ideal for large files.

### Q39. How do you prevent overwriting an existing file?
Use `FileMode.CreateNew`. It fails if the file already exists.

```csharp
using FileStream fs = new FileStream(
    "data.txt", FileMode.CreateNew, FileAccess.Write);
```

### Q40. What should you consider when writing files in a multi-request API?
Use unique filenames, handle concurrent access and errors, validate uploads, restrict permissions, and clean up temporary files.
"""
path = Path("/mnt/data/CSharp_File_Handling_Short_Notes.md")
path.write_text(content, encoding="utf-8")
print(f"Created: {path}")
