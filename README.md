This project is a frontend for a bookstore application, built using .NET Core. It is designed to provide a user-friendly interface for browsing books, managing user accounts, and processing transactions.

Project Structure
The project is organized into several key directories and files:

-Controllers/: Contains controller classes that handle HTTP requests and responses.
-Models/: Defines the data models used by the application.
-Views/: Contains Razor view files for generating the HTML content.
-Properties/: Includes the project's properties files.
-Program.cs: The entry point of the application, configuring the web host.
-Startup.cs: Configures services and the app's request handling pipeline.
-appsettings.json/appsettings.Development.json: Configuration files for the application.
-css/, js/, less/, scss/, sprites/, webfonts/: Directories for static assets like stylesheets, JavaScript files, and other assets.
-jquery/, jquery-validation/, jquery-validation-unobtrusive/, bootstrap/: Libraries and frameworks for frontend development.
-favicon.ico: The icon that appears in the browser tab.
-LICENSE.txt: The license under which the project is released.
-sprint_books.csproj, sprint_books.csproj.user: Visual Studio project files.
-metadata/, obj/: Contain generated files for project metadata and object files.

Setup Instructions
Prerequisites
.NET Core SDK (Version specified in sprint_books.csproj)
Visual Studio or Visual Studio Code
Running the Project
Clone the repository to your local machine.
Open the project in Visual Studio or Visual Studio Code.
Restore the required packages by running dotnet restore.
Start the application by running dotnet run within the project directory or by using the IDE's built-in run command.
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
