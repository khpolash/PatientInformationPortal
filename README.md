# Project Name

Patient Information portal

## Introduction

This module provides a patient entry form for managing patient information within the portal.

## Features

### Patient Entry Form

- Insert new patient information.
- Update existing patient information.
- Delete patient records.
- Display a list of all patients with basic details.


### Disease Entry Form

- Insert new Disease information.
- Update existing Disease information.
- Delete Disease records.
- Display a list of all Diseases.

### Allergy Entry Form

- Insert new Allergy information.
- Update existing Allergy information.
- Delete Allergy records.
- Display a list of all Allergies.

## Prerequisites

Before you begin, ensure you have the following prerequisites installed:

- **.NET SDK**: Install the .NET SDK appropriate for your platform. You can download it from the official [.NET website](https://dotnet.microsoft.com/download).
- **MySQL Database**: MySQL database server is required to store patient information. Install MySQL Server and ensure it is running.

## Installation

Follow these steps to set up and run the application:

1. **Clone the Repository**: 
    ```bash
    git clone <repository-url>
    ```
    
2. **Open the Project in Visual Studio 2022**: 
    Open Visual Studio 2022 and open the solution file (.sln) of the project.

3. **Configure Database Connection**: 
    Update the database connection string in the `appsettings.json` file with your MySQL database connection details.
    
4. **Create Database**: 
    After Update the database connection string in the `appsettings.json` file run command ```update-database.

5. **Build and Run the Application**: 
    - Build the solution by selecting "Build > Build Solution" from the menu.
    - Run the application by pressing F5 or selecting "Debug > Start Debugging" from the menu.

6. **Access the Application**: 
    Navigate to the URL where the application is hosted in your web browser.

## Troubleshooting

If you encounter any issues during installation or while running the application, consider the following troubleshooting steps:

- Ensure the database connection string in the `appsettings.json` file is correct.
- Check MySQL server logs for any error messages related to database connections.
- Review ASP.NET Core logs for any application-specific error messages.

## Contributing

Contributions are welcome. Fork the repository, make your changes, and submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
