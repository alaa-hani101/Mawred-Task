# Candidate Management API

A simple ASP.NET Core Web API for managing candidates applying to different tracks in the Mawred Platform.

The project demonstrates the fundamentals of building RESTful APIs using ASP.NET Core, Entity Framework Core, validation, DTOs, and clean project organization.

---


## Features

* Add a new candidate
* Retrieve all candidates
* Retrieve a candidate by ID
* Update candidate status
* Delete a candidate
* Input validation using Data Annotations
* Entity Framework Core integration
* Repository Pattern implementation
* Result Pattern for consistent operation outcomes
* DTOs for request and response models
* Asynchronous programming with `async/await`
* Swagger (OpenAPI) documentation
* Clean and maintainable project structure
* RESTful API design


---

## Technologies Used

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server / SQLite / InMemory Database
* Swagger (OpenAPI)
* C#
* .NET 10

---

## Project Structure

```
CandidateManagementAPI
│
├── Controllers
    ├── Base
├── Models
    ├── Enums
├── DTOs
    ├── Requests
    ├── Responses
├── Data
    ├── Configurations
├── Repositories
    ├── Interfaces
    ├── Implementations
├── Services
    ├── Interfaces
    ├── Implementations
├── Migrations
└── Program.cs
```

---

## API Endpoints

### Candidates

| Method | Endpoint                      | Description             |
| ------ | ----------------------------- | ----------------------- |
| POST   | `/api/candidates`             | Add a new candidate     |
| GET    | `/api/candidates`             | Get all candidates      |
| GET    | `/api/candidates/{id}`        | Get candidate by ID     |
| PATCH    | `/api/candidates/{id}/status` | Update candidate status |
| DELETE | `/api/candidates/{id}`        | Delete candidate        |

---

## Validation Rules

* Full Name is required.
* Email is required.
* Email must be valid.
* Track is required.
* Level is required.

---

## Running the Project

### Clone the repository

```bash
git clone https://github.com/alaa-hani101/Mawred-Task
```

### Navigate to the project

```bash
cd Mawred-Task 
```

### Restore packages

```bash
dotnet restore
```

### Apply migrations

```bash
dotnet ef database update
```

### Run the project

```bash
dotnet run
```

Swagger will be available at:

```
https://localhost:xxxx/swagger
```

---

## Sample Candidate JSON

```json
{
  "fullName": "Alaa Hani",
  "email": "alaa@example.com",
  "track": 1,
  "level": 2
}
```

---

## Possible Future Improvements

This project was intentionally kept simple for the assessment, but it can be extended with several production-ready features such as:

* JWT Authentication & Authorization
* Role-Based Access Control (Admin / Recruiter)
* Generic Repository & Unit of Work Pattern
* FluentValidation
* AutoMapper
* Pagination, Filtering & Searching
* Sorting
* Soft Delete instead of permanent delete
* Audit Logging
* Email Notifications
* Docker Support
* API Versioning
* Rate Limiting
* Serilog Logging
* Health Checks
* CI/CD Pipeline using GitHub Actions
* Deployment to Azure or Render

---

## Author

**Alaa Hani**

Backend Developer | ASP.NET Core | Entity Framework Core | REST APIs
