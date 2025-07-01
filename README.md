# API Testing with C# and xUnit Framework

This project contains automated API tests for the [restful-api.dev](https://restful-api.dev/) REST API using C#, xUnit, and is designed to be executed in Visual Studio Code with `.NET 9 SDK`.

---

## 📁 Project Structure

```
XUnit Test/
├── Models/                # API response and request models  
│   └── DeleteResponse.cs  
│   └── Item.cs  
│   └── ItemPost.cs  
│   └── ItemResponse.cs  
│   └── ItemUpdate.cs  
├── Test/                  # Test data and providers  
│   └── Tests.cs  
```

---

## ✅ Test Coverage

The test suite covers the following scenarios:

### 🔹 Getting a list of all objects
- Validates response structure  
- Ensures non-empty list  
- Verifies object properties  

### 🔹 Creating a new object
- Validates successful creation  
- Verifies object structure  
- Confirms data matches input  

### 🔹 Retrieving a single object
- Gets object by ID  
- Validates object properties  
- Verifies data consistency  

### 🔹 Updating existing objects
- Updates object properties  
- Validates response  
- Confirms changes applied  

### 🔹 Deleting objects
- Removes object  
- Verifies deletion  
- Checks 404 after deletion  
- Error handling  

### 🔹 Negative Testing
- Get non-existent object  
- Delete non-existent object  

---

## 🚀 Setup Instructions

### 🔗 Clone the Repository

```bash
git clone https://github.com/Dhanushkaak47/API-Test-using-C-.git
cd API-Test-using-C-
```

### 🛠 Prerequisites

Ensure the following are installed:

1. .NET 9 SDK  
   Verify installation:
   ```bash
   dotnet --version
   ```

2. VS Code Extensions  
   - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) *(or C# for Visual Studio Code powered by OmniSharp)*  
   - [.NET Install Tool for Extension Authors](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-install-tool)  
   - [Test Explorer UI (Optional)](https://marketplace.visualstudio.com/items?itemName=hbenl.vscode-test-explorer) *(for GUI test runner)*  

---

## ⚙️ Running the Project

### 🔄 Restore NuGet Packages

```bash
dotnet restore
```

### 🏗 Build the Project

```bash
dotnet build
```

### 🧪 Run Tests

```bash
dotnet test
```

All xUnit tests will be executed and results will be displayed in the terminal.

---

## 🧑‍💻 Author

**Dhanushka Madhusanka**  
[GitHub](https://github.com/Dhanushkaak47)

---
