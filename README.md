# XUnit Test
API Testing with Playwright
This project contains automated API tests for the restful-api.dev REST API using Playwright.

Project Structure
XUnit Test/
├── Models/                # API Responses and req models
│   └── objects.api.ts
├── Test/              # Test data and providers
│   └── providers/
│       └── object.provider.ts


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
Prerequisites
Node.js (v14 or higher)
npm (comes with Node.js)
