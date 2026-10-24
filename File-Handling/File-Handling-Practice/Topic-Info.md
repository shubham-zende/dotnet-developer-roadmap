# File Handling in C#

- **File Handling:** The process of creating, reading, writing, appending, and deleting files in C#. It is mainly provided by the `System.IO` namespace.

### 1. File Handling Classes

1. **FileStream:** Reads and writes data using a stream of bytes.
2. **StreamWriter:** Writes character data to a file.
3. **StreamReader:** Reads character data from a file, line by line or as a stream.
4. **BinaryWriter:** Writes primitive data types in binary format.
5. **BinaryReader:** Reads primitive data types in binary format.
6. **DirectoryInfo:** Creates, deletes, and gets information about directories.
7. **FileInfo:** Creates, deletes, and gets information about files.
8. **Directory:** Provides static methods to create, delete, and check directories.
9. **File:** Provides static methods to create, read, write, copy, and delete files.

### 2. File Access Modes (`FileAccess`)

1. **Read:** Allows reading from a file.
2. **Write:** Allows writing to a file.
3. **ReadWrite:** Allows both reading and writing.

### 3. File Modes (`FileMode`)

1. **Open:** Opens an existing file. Throws an exception if the file does not exist.
2. **Create:** Creates a new file or overwrites an existing file.
3. **OpenOrCreate:** Opens an existing file or creates a new one.
4. **CreateNew:** Creates a new file. Throws an exception if the file already exists.
5. **Append:** Opens a file and writes data at the end. Creates the file if it does not exist.
6. **Truncate:** Opens an existing file and removes all its contents.

**Note:** `FileAccess` defines what operations are allowed, while `FileMode` defines how the file is opened or created.