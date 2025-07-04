
# ContactApp

This application is a RESTful API for managing contact information. It allows clients to create, retrieve, update, and validate contact records, including optional details like phone, email, and categorized subgroups. Input data is validated using FluentValidation, with both synchronous and asynchronous rules. The app supports seeding initial data into the database.
App does not have frontend coded, and provides a Swagger UI for easy testing and documentation instead.


## Installation & Setup

### 1. Clone the repository
```bash
git clone https://github.com/your-username/your-repo-name.git
```

### 2. Navigate to API project
```bash
cd ContactApi/
```

### 3. Restore packages
dotnet restore

### 4. Config appsettings.json file: 
- Connection strings;
- UseSqlServer (if false uses SQLite database instead)
- JWT settings (key must be at lest 512 bits long)


### 5. Apply database migrations & seed data
```bash
dotnet ef migrations add init
dotnet ef database update
```

### 6. Run the app
```bash
dotnet watch run
```
## Liberies & Dependencies

- **ASP.NET Core Web API** - (Minimal APIs / Controllers)
- **Entity Framework Core** – ORM with SQL Server or SQLite
- **FluentValidation** – Model validation
- **Swashbuckle.AspNetCore** – Swagger UI & OpenAPI
- **Bcrypt** - Password Hashing for Contacts
- **JWT Bearer Authentication** - Stateless, token-based authentication (JSON Web Tokens)
- **BCrypt.Net-Next** - Secure password hashing used by Identity
- **SQLite / SQL Server (configurable)** - Supported databases for development and production
- **ASP.NET Core Identity** - User registration, authentication, and password management
## Class Overview


- **Program.cs** - App startup, middleware pipeline, DI registration
- **Controllers/** - API endpoints (e.g. ContactsController)
- **Services/** - API business logic (e.g. ContactsService)
- **Models/** - Data models (e.g. Contact)
- **DTOs/** - Request/response objects (CreateContactDto, etc.)
- **Validators/** - FluentValidation rules per model/DTO
- **Data/AppDbContext.cs** - EF Core DB context


## Authors

- [@Jelinskyy](https://www.github.com/Jelinskyy)