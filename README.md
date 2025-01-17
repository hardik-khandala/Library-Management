# Library Management API

## Overview
The **Library Management API** is a .NET Core Web API for managing a library's collection of books. It provides functionality to perform CRUD operations, retrieve books based on different filters, handle pagination, and implement business logic such as stock validation and sorting.

## Features
1. **CRUD Operations**:
   - Retrieve all books.
   - Retrieve a specific book by ID.
   - Add a new book.
   - Update book details.
   - Delete a book with stock validation.
2. **Custom Endpoints**:
   - Retrieve books by author name.
   - Retrieve books published in a specific year.
   - Retrieve books by title (supports partial matches).
   - Retrieve only books with stock greater than 0.
3. **Pagination**:
   - Paginate results using query parameters `pageNumber` and `pageSize`.
4. **Sorting**:
   - Sort books by `Title` or `Price` in ascending or descending order.
5. **Validation and Business Logic**:
   - Prevent deletion of books with stock greater than 50.
   - Ensure all input data is valid with meaningful error messages.

---

## Requirements
- **.NET Core 6.0 or higher**
- **SQL Server** (or any compatible database supported by Entity Framework Core)
- Tools: Visual Studio or VS Code, Postman (for manual testing), Swagger UI (for API documentation).

---

## Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/hardik-khandala/Library-Management.git
cd Library-Management
dotnet restore
dotnet build
dotnet run
```
