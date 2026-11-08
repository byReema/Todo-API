# Todo API

A learning project for building a REST API with ASP.NET Core, Entity Framework Core, and MySQL.

## What it includes

- Todo CRUD endpoints backed by MySQL
- A controller, service, and data context structure
- Request DTOs with basic validation
- Category endpoints and a one-to-many category-to-todos relationship model
- EF Core migrations

Category assignment on todos is still being developed.

## Tech stack

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core 10
- MySQL 8+

## Run locally

1. Create a MySQL database named `todo_api`.
2. From the project folder, configure the local connection string with User Secrets. Run `init` only once per project; if it was already initialized, just run `set`:

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:TodoDatabase" "Server=localhost;Port=3306;Database=todo_api;User=YOUR_MYSQL_USER;Password=YOUR_MYSQL_PASSWORD;"
   ```

   Replace the placeholders with your local MySQL credentials. Don’t commit real credentials.

3. Install the EF command-line tool if needed, then create/update the database schema:

   ```bash
   dotnet tool install --global dotnet-ef --version 10.0.12
   dotnet ef database update
   ```

4. Start the API:

   ```bash
   dotnet run
   ```

Use the local URL printed by `dotnet run` with the routes below.

## API routes

### Todos

| Method | Route | Purpose |
| --- | --- | --- |
| `GET` | `/todos` | List todos |
| `GET` | `/todos/{id}` | Get a todo |
| `POST` | `/todos` | Create a todo |
| `PUT` | `/todos/{id}` | Update a todo |
| `DELETE` | `/todos/{id}` | Delete a todo |

### Categories

| Method | Route | Purpose |
| --- | --- | --- |
| `GET` | `/categories` | List categories |
| `GET` | `/categories/{id}` | Get a category |
| `POST` | `/categories` | Create a category |

## Example request bodies

Create a todo:

```json
{
  "name": "Learn EF Core",
  "dueDate": "2026-11-15T18:00:00",
  "isCompleted": false
}
```

Create a category:

```json
{
  "name": "Learning"
}
```
