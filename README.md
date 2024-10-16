# AutoDealer

## Project Description

AutoDealer is an MVC project designed to help users manage and browse car listings. The main features of the project include:

- Adding, editing, and deleting car listings
- Searching and filtering car listings based on various criteria
- Viewing detailed information about each car
- User authentication and authorization
- Admin panel for managing users and car listings

![image](https://github.com/DesislavAr/AutoDealer/blob/master/Screenshot%20(11).png?raw=true)

![image](https://github.com/DesislavAr/AutoDealer/blob/master/Screenshot%20(12).png?raw=true)

![image](https://github.com/DesislavAr/AutoDealer/blob/master/Screenshot%20(14).png?raw=true)

![image](https://github.com/DesislavAr/AutoDealer/blob/master/Screenshot%20(15).png?raw=true)

## Features

- User registration and login
- Add, edit, and delete car listings
- Search and filter car listings
- View detailed information about cars
- Admin panel for managing users and car listings

## Installation

### Prerequisites

- .NET Framework 4.7
- Visual Studio 2017 or later
- SQL Server

### Steps

1. Clone the repository:
   ```bash
   git clone https://github.com/DesislavAr/AutoDealer.git
   ```

2. Open the solution in Visual Studio.

3. Restore the NuGet packages:
   ```bash
   Update-Package -reinstall
   ```

4. Update the database connection string in `Web.config` to point to your SQL Server instance.

5. Run the Entity Framework migrations to create the database schema:
   ```bash
   Update-Database
   ```

6. Build and run the project.

## Usage

### Running the Project

1. Open the solution in Visual Studio.
2. Press `F5` to build and run the project.

### Using the Features

- Register a new user account or log in with an existing account.
- Browse the car listings on the home page.
- Use the search and filter options to find specific cars.
- Click on a car listing to view detailed information.
- If you are an admin, access the admin panel to manage users and car listings.

## Contributing

We welcome contributions to the AutoDealer project. To contribute, please follow these guidelines:

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes and commit them with descriptive commit messages.
4. Push your changes to your forked repository.
5. Create a pull request to the main repository.

### Code of Conduct

We expect all contributors to adhere to the project's code of conduct. Please read the [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) file for more information.

## License

This project is licensed under the Apache License, Version 2.0. See the [LICENSE.md](LICENSE.md) file for more details.
