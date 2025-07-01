API Testing with C# and the Xunit Framework
This project contains automated API tests for the restful-api.dev REST API using Playwright.

Project Structure
XUnit Test/
├── Models/                # API Responses and req models
│   └── DeleteResponse.cs
│   └── Item.cs
│   └── ItemPost.cs
│   └── ItemResponse.cs
│   └── ItemUpdate.cs
├── Test/              # Test data and providers
│   └── Tests.cs
 

Test Coverage
The test suite covers the following scenarios:

Getting a list of all objects

Validates response structure
Ensures non-empty list
Verifies object properties

Creating a new object

Validates successful creation
Verifies object structure
Confirms data matches input

Retrieving a single object

Gets object by ID
Validates object properties
Verifies data consistency

Updating existing objects

Updates object properties
Validates response
Confirms changes applied

Deleting objects

Removes object
Verifies deletion
Checks 404 after deletion
Error handling

Get Non-existent object
Delete Non-existent object

Setup
Clone Git repository
https://github.com/Lahiruhiran/playWrightAssessment/tree/playwrightAeesement

1.	Install .NET 9 SDK
Make sure you have the .NET 9 SDK installed. You can check with:
dotnet --version

2.	Install VS Code Extensions
•	C# Dev Kit (or C# for Visual Studio Code (powered by OmniSharp))
•	.NET Install Tool for Extension Authors (if prompted)
•	Test Explorer UI (optional, for a GUI test runner)

3.	Open the Project Folder
Open the root folder of your project in VS Code (the folder containing your .csproj file).
4.	Restore NuGet Packages
In the terminal, run:
dotnet restore

5.	Build the Project
dotnet build

6.	Run the Tests
dotnet test

This will execute all your xUnit tests and show the results in the terminal.
