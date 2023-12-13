# CmcMarkets Tech Test

# Backend - .NET Core WebApi

## Overview

This project is a showcase .NET Core backend application that provides API endpoints for user-related operations of a Tasks application, advanced queries, asynchronous programming, and robust exception handling.

## Design Choices

- **Multi-layer Design:** This application separates concerns of each layer from WebApi to Service to Persistence(DAL). It injects concrete implementations of abstractions to higher components in the structure.

- **Microsoft Identity:** Used this powerful library to manage users, passwords, profile data, roles, claims and tokens.

- **Entity Framework:** EF allows to create a database from code, which enables a more agile and test-driven development workflow. Also integrated Microsoft Identity entities to the same database as the application entities are stored. SQL Server Express has been used for the database.

- **Repository Pattern:** Used Repository as an abstraction of the Data Access Layer. It hides details of how exactly the data is saved and retrieved from underlying data source. So it also enables us to easily test application with unit tests.

- **Unit of work Pattern:** The unit of work design pattern guarantees data integrity and consistency in applications. It ensures that all changes made to multiple objects in the application are committed to the database or rolled back.

- **Test Harness:** It allows developers to seed the database with initial users, roles and some user tasks to start with. It can Login, Register user and admin.

- **Unit Tests:** With testability in mind when designing classes, the entire application can be unit tested. A couple of them have been showcased for this presentation.

- **Asynchronous Programming:** Demonstrated the use of asynchronous programming ensuring efficient handling of concurrent requests. Async/await is used in database operations to avoid blocking. All methods in the application are called asynchronously from Persistance to Service to WebApi layers.

- **Exception Handling:** Implemented robust exception handling to ensure the application gracefully handles common errors. Returns appropriate HTTP status codes and provides informative error messages to clients. In the api sample, it will return 404 status code if no result is found and returns 500 if an internal server error happens. Otherwise it will return a list of user tasks.

## Libraries Used

- **Entity Framework Core:** Used for database integration and ORM.
- **ASP.NET Core Identity:** Implemented for user authentication and authorization.
- **Automapper:** To map database entities to domain based DTOs to return to Api
- **MS Test and Moq:** Used for unit testing
- **Dependency Injection:** Haviliy used for clean code purposed and making the application easily testable
- **Swagger:** Helps to build documentation and test APIs

## How to Run

#### Cloning

1- Clone the repository.
(and change directory to CmcMarkets.Backend folder)

#### Database EF migration

2- Set up the database connection in `appsettings.json`

3- Run the database migrations: (from CmcMarkets.Backend/CmcMarkets.Backend.WebApi folder)

```bash
dotnet ef database update
```

#### Seeding some users and user tasks through `Test Harness`

4- Run the .NET Core TestHarness:
(from CmcMarkets.Backend folder)

```bash
dotnet run --project ./CmcMarkets.Backend.Tests.TestHarness/CmcMarkets.Backend.Tests.TestHarness.csproj
```

5- Open your browser and navigate to `http://localhost:5000/swagger`

6- Create Users and Roles by running `/Application/seedUsersAndRoles` endpoint

7- Seed some user tasks by running `/Application/seedUserTasks` endpoint

8- Login as `user@example.com` with password `User@123` using `/Authenticate/login`
(for admin user, login as `admin@example.com` with password `Admin@123`)

9- Save the token from last step and keep it somewhere

10- Stop Test Harness application

#### Main Application

11- Run the .NET Core WebApi: (from CmcMarkets.Backend folder)

```bash
dotnet run --project ./CmcMarkets.Backend.WebApi/CmcMarkets.Backend.WebApi.csproj
```

12- Open your browser and navigate to `http://localhost:5000/swagger`

13- Authorize to Swagger by clicking on `Authorize` button on top of the screen and paste the token saved in the previous steps

14- Run `/UserTask/getRecentTasks` endpoint to see the result

15- Try logging in with an Admin role and see we get authorization exception

## Additional Notes

- Make sure to configure the appropriate database connection strings in `appsettings.json`.
- Explore the Swagger documentation for details on available API endpoints and request/response formats.
- For the sake of simplicity of running this presentation, all security settings like Issuer, Audience, SecretKey and ConnectionString are left in the project. In a real application, they should not be checked in and should use Cloud secret manager and CI/CD inject variables instead.

# Frontend - React ToDo App

## Overview

This project is a simple ToDo app built using React. It allows users to add, mark as completed, and delete ToDo items.

## Design Choices

- Used React for the UI component.
- Utilized Redux Toolkit for state management. It stores user tasks in memory and doesn't call any external APIs for this presentation.
- Styled the app using SCSS in the form of CSS Modules.
- Used ErrorBoundary to hide the error details from the end user

## Libraries Used

- React
- Redux Toolkit
- Jest
- Sass

## How to Run

1. Clone the repository.
2. Change to from CmcMarkets.Frontend folder
3. Run `npm install` to install dependencies.
4. Run `npm start` to start the development server.
5. Open your browser and navigate to `http://localhost:3000`.

## How to Test

1. Run `npm test` to execute the test suite.

# Next Steps

This solution can be developed even further with the following steps in the future:

- **Complete Backend:** For the purpose of this demo, only a limited APIs have been introduced, however in order to serve as a real backend for Todo application, it needs to provide all CRUD operations.
- **Connect Frontend to Backend:** After completing Backend providing all needed operations, Frontend needs to call those APIs through Redux Toolkit Async Thunks.
- **UI Authentication:** At the moment, authentication and user registration is done by TestHarness project. In a real world application, this functionality needs to be properly done through UI. So creating React components for login, register and logout will make the authentication possible through UI.
- **Containerization:** It is difficult to bring up backend, frontend and database in order to run end to end feature altoghether. By containerizing and using Docker, can package the solution into images and deploy into a containerized enviroment and run safely.

Feel free to reach out if you have any questions or need further clarification.
