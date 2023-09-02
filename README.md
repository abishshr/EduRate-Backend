# EduRate API

The EduRate API is a web service for rating educational modules and interactions.

## Features

- User Authentication using JWT
- CRUD operations for Modules, Ratings, Reviews, and Interactions
- Authorization and role-based access control

## Technologies Used

- .NET 6
- Entity Framework Core
- JWT for Authentication
- Swagger for API documentation

---

## Setup

### Prerequisites

- Install .NET SDK 6.0 or higher.
- (Optional) A tool for API testing like Postman or use the built-in Swagger UI.

### Installation on Windows

1. Clone the repository.
    ```bash
    git clone https://github.com/your_username/EduRate-Api.git
    ```

2. Navigate to the project folder.
    ```bash
    cd EduRate-Api
    ```

3. Restore the project dependencies.
    ```bash
    dotnet restore
    ```

4. Run the project.
    ```bash
    dotnet run
    ```

### Installation on Mac

1. Clone the repository.
    ```bash
    git clone https://github.com/your_username/EduRate-Api.git
    ```

2. Navigate to the project folder.
    ```bash
    cd EduRate-Api
    ```

3. Restore the project dependencies.
    ```bash
    dotnet restore
    ```

4. Run the project.
    ```bash
    dotnet run
    ```

---

## Using Swagger

The API comes with Swagger documentation and UI enabled.

1. After running the project, navigate to:
    ```
    https://localhost:5001/swagger/index.html
    ```
   (Or the appropriate URL if you've changed the default port settings.)

2. You will see the list of available API endpoints.

3. To authenticate, click on the "Authorize" button and enter your JWT token in the format `Bearer YOUR_JWT_TOKEN`.

4. You can now execute API operations from the Swagger UI.

---
## Application URL for Frontend

Frontend applications should use the following base URL to call the API:
   ```
   https://localhost:5000
   ```
Or the appropriate URL if you've changed the default port setting

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

MIT
