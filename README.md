# SaadiaInventorySystem
Saadia Inventory System: A desktop application for Inventory management and Invoice and quotation related needs.

Overview:
A desktop application build using WPF(MVVM) with the backend developed using .Net Core. Saadia Inventory system is a desktop application developed to provide a simplistic
and easy to use inventory stock management and the customers orders, quotations and invoices. Saadia Inventory System also allows importing of Excel Files and export of quotations,
invoices and inventory part as excel and to PDF.

Getting Started
The following are required to run the program locally.

Visual Studio 2019 Community with .NET Core 3.0 SDK
GitBash / Terminal or GitHub Extension for Visual Studio
Clone the repository to your local machine.
Cd into the application directory where the SaadiaInventorySystem.sln exist.
Open the application using Open/Start SaadiaInventorySystem.sln.
Once the App is opened, Right click on the application name from the Solution Explorer Window and find ASP.NET Configuration File.
Inside this file, change the Connection String to the following to connect to database:

"ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=saadiatrading;user=root;password=;TreatTinyAsBoolean=true"
}

Click Tools -> NuGet Package Manager -> Package Manager Console then run the following commands in the console.
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Add-Migration Initial
- Update-Database

Once the database is updated, you can Run the application by clicking on the Play button .
