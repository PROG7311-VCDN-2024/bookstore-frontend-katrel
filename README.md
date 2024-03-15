Below is an enhanced version of the README content you've provided, incorporating the additional features and functionalities related to admin roles and authentication:

---

# Sprint Books Frontend Application

This project serves as the frontend for a bookstore application, developed with .NET Core. It aims to offer a seamless user experience for book browsing, account management, and transaction processing.

## Project Structure

The application is structured into several key directories and files for organized development and maintenance:

- **Controllers/**: Hosts controller classes to manage HTTP request and response handling.
- **Models/**: Contains data models for application entities.
- **Views/**: Includes Razor view files for HTML content rendering.
- **Properties/**: Houses the project's property files.
- **Program.cs**: Serves as the entry point, setting up the web host.
- **Startup.cs**: Configures services and the application's request handling pipeline.
- **appsettings.json/appsettings.Development.json**: Application configuration files.
- **Static Assets Directories (css/, js/, less/, scss/, sprites/, webfonts/)**: For stylesheets, JavaScript, and other front-end assets.
- **Frontend Libraries (jquery/, jquery-validation/, jquery-validation-unobtrusive/, bootstrap/)**: Contains libraries and frameworks for UI development.
- **favicon.ico**: The application's browser tab icon.
- **LICENSE.txt**: The project's licensing information.
- **Project Files (sprint_books.csproj, sprint_books.csproj.user)**: Visual Studio project files.
- **Generated Directories (metadata/, obj/)**: For project metadata and object files.

## Setup Instructions

### Prerequisites

- .NET Core SDK (version as specified in `sprint_books.csproj`)
- Visual Studio or Visual Studio Code

### Running the Project

1. Clone the repository to your local machine.
2. Open the project in Visual Studio or Visual Studio Code.
3. Restore the necessary packages by running `dotnet restore`.
4. Start the application with `dotnet run` in the project directory or utilize the IDE's run command.

## Contributing

For contribution guidelines, please refer to the `LICENSE.txt` file for licensing information and policies.

## Key Features

- **Browse Books**: View a catalog of books with details like title, author, genre, and cover images.
- **Book Details**: Access in-depth information on books including summaries, publication dates, prices, and reviews.
- **Search and Filter**: Look for books using title, author, or genre and apply filters for refined search results.
- **User Accounts**: Allows users to create accounts, save favorite books, manage purchases, and access exclusive content.
- **Shopping Cart**: Enables adding books to a cart, viewing cart contents, and proceeding to checkout.

## Admin Features

- **Admin Login**: Secure login for administrators using Firebase Authentication.
- **Manage Admins**: Add other administrators to the system.
- **View Customer Orders**: Administrators can view orders placed by customers.
- **Item Inventory Management**: Ability to add and manage inventory items.
- **Update Item Quantity**: Admins can adjust the available quantity of items in stock.
- **Data Validation**: Ensure no items or orders are added with missing fields through comprehensive data validation.

## Authentication

- All authentication processes are implemented using Firebase Authentication, ensuring secure access for both users and administrators.

---

This structured README provides a comprehensive overview of your bookstore application's frontend, including setup instructions, features, and admin functionalities. dotnet run within the project directory or by using the IDE's built-in run command.
Contributing
Please read LICENSE.txt for information on the project's license and the contributions policy.

Key Features
Browse Books: Users can view a list of books, including their titles, authors, genres, and cover images.
Book Details: Clicking on a book provides more detailed information, such as a summary, publication date, price, and reviews.
Search and Filter: Users can search for books by title, author, or genre and apply filters to narrow down their search results.
User Accounts: Users can create accounts to save their favorite books, manage purchases, or access exclusive content.
Shopping Cart: A feature for users to add books to a cart, view their cart contents, and proceed to checkout.![final erd sprint](https://github.com/PROG7311-VCDN-2024/bookstore-frontend-katrel/assets/103831256/5cfc0d61-85c0-4a34-a28e-347a2ba986f0)
![System architecure diagram sprinte 1](https://github.com/PROG7311-VCDN-2024/bookstore-frontend-katrel/assets/103831256/195ba692-88cf-49a5-b79b-668fbacba023)


License
This project is licensed under the terms included in the LICENSE.txt file.
