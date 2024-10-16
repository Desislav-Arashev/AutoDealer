# Contributing to AutoDealer

We welcome contributions to the AutoDealer project. To contribute, please follow these guidelines:

## How to Contribute

1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Make your changes and commit them with descriptive commit messages.
4. Push your changes to your forked repository.
5. Create a pull request to the main repository.

## Code of Conduct

We expect all contributors to adhere to the project's code of conduct. Please read the [CODE_OF_CONDUCT.md](CODE_OF_CONDUCT.md) file for more information.

## Reporting Issues

If you encounter any issues or bugs, please report them by creating a new issue in the GitHub repository. Provide as much detail as possible, including steps to reproduce the issue and any relevant screenshots.

## Submitting Pull Requests

When submitting a pull request, please ensure that your changes are well-documented and include any necessary tests. Follow the coding standards outlined below.

## Coding Standards

- Use meaningful variable and function names.
- Write clear and concise comments.
- Follow the project's coding style and conventions.
- Ensure that your code is properly formatted and linted.

## Setting Up the Development Environment

To set up the development environment, follow these steps:

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
