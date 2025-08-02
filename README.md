# Hospital Management System

This is a web-based Hospital Management System built using ASP.NET MVC framework. The system provides functionality for managing hospital operations, doctors, departments, and news/articles.

## Features

- Doctor Management
- Department Management
- News/Articles Management
- Administrative Dashboard
- Responsive Design
- Multi-language Support

## Technology Stack

- ASP.NET MVC
- C#
- Bootstrap
- jQuery
- HTML5/CSS3
- JavaScript
- Font Awesome
- Various JS libraries (BxSlider, Owl Carousel, Fancybox, etc.)

## Project Structure

```
├── App_Start/            # Application startup configurations
├── Areas/               # Admin area for administrative functions
├── Controllers/         # MVC Controllers
│   ├── BacSiAPIController.cs
│   ├── DepartmentController.cs
│   ├── DoctorController.cs
│   ├── HomeController.cs
│   └── TinTucController.cs
├── Models/              # Data models
├── Views/               # MVC Views
├── Content/            # CSS and other content files
├── Scripts/            # JavaScript files
└── assets/             # Additional assets and libraries
```

## Features in Detail

### Doctor Management
- View doctor profiles
- Search doctors
- Doctor scheduling

### Department Management
- View departments
- Department details
- Services offered

### News Management
- Hospital news and updates
- Health articles
- Medical information

## Installation

1. Clone the repository
2. Open the solution in Visual Studio
3. Restore NuGet packages
4. Update the database connection string in Web.config
5. Build and run the application

## Requirements

- Visual Studio 2019 or later
- .NET Framework 4.5+
- SQL Server

## License

This project is licensed under the MIT License.
