
<div align="center">
  <a href="https://github.com/hossameltayeb83/InsightHive">
    <img src="assets/InsighHivelogo.svg" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Insight Hive</h3>

  <p align="center">
    You Make The Stars!
  </p>
</div>

# Insight Hive

Insight Hive is a robust web application enabling users to review and rate businesses they've interacted with, while allowing business owners to list their enterprises and provide detailed information. Users can filter businesses based on various criteria to find the best options.

Insight Hive is built using Clean Architecture and CQRS (Command Query Responsibility Segregation) principles, ensuring a scalable, maintainable, and efficient system.
## Features
Comprehensive Reviews and Ratings: Share detailed reviews and rate businesses based on your experiences, helping others make informed decisions.
### For Reviwers:
1. **Reviews and Ratings:** Share detailed reviews and rate businesses based on their experiences, helping others make informed decisions.
2. **Advanced Filtering:** Easily find businesses that meet specific criteria by using advanced filtering options.
3. **User Profile:** Create and manage their profile, track review history, and see how many people found their reviews helpful.
4. **Badges Reward:** Top Reviwers and contributors recieve badges that show their engagement with the community.

### For Owners:
1. **Business Management:** Add and manage business listings, including detailed descriptions, contact information, and service offerings to attract potential customers.
2. **Customer Feedback:**  Respond to reviews, engage with customers, and address their concerns to improve business reputation and customer satisfaction.

### Built With

- [ASP.NET Core Web API](https://learn.microsoft.com/en-us/aspnet/core/web-api) - A rich framework for building web apps and APIs using the Model-View-Controller design pattern.
- [SQL Server](https://www.microsoft.com/en-us/sql-server/) - A proprietary relational database management system developed by Microsoft.
- [Entity Framework (EF) Core](https://learn.microsoft.com/en-us/ef/core/) - An open-source object-relational mapping (ORM) framework developed by Microsoft.
- [MediatR](https://www.nuget.org/packages/MediatR) - Simple, unambitious mediator implementation in .NET
- [AutoMapper](https://automapper.org/) - A convention-based object-object mapper. Takes out all of the fuss of mapping one object to another.
- [FluentValidation](https://fluentvalidation.net/) - .NET library for building strongly-typed validation rules.
- [HangFire](https://www.hangfire.io/) - An easy way to perform background processing in .NET and .NET Core applications.
<br/>

## Contributors
The dedicated developers whose hard work and expertise brought this project to life.
<table>
  <tr>
    <td align="center" valign="top" width="15%"><a href="https://github.com/omarel3ashry" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/32119955?v=4"  width="100px;" /><br /><sub><b>Omar Elashry</b></sub></a><br /></td>
    <td align="center" valign="top" width="15%"><a href="https://github.com/karimalshal666" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/157370888?v=4"  width="100px;" /><br /><sub><b>Karim Alshal</b></sub></a><br /></td>
    <td align="center" valign="top" width="20%"><a href="https://github.com/Mo3bdelrahman" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/61760258?v=4"  width="100px;" /><br /><sub><b>Mohamed Abdelrahman</b></sub></a><br /></td>
    <td align="center" valign="top" width="15%"><a href="https://github.com/hossameltayeb83" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/96459585?v=4"  width="100px;" /><br /><sub><b>Hossam Eltayeb</b></sub></a><br /></td>
    <td align="center" valign="top" width="15%"><a href="https://github.com/nourhanbelal22" style:"border-radius:50%;"><img src="https://avatars.githubusercontent.com/u/157370503?v=4"  width="100px;" /><br /><sub><b>Nourhan Belal</b></sub></a><br /></td>
  </tr>
</table>

<br/>

## Installation

To run InsightHive locally, follow these steps:

1. **Clone the repository:**
   
   ```
   git clone https://github.com/hossameltayeb83/InsightHive
   ```
   
3. **Navigate to the project directory:**
   
   ```
   cd InsightHive
   ```
   
4. **Install dependencies:**
   
   ```
   dotnet restore
   ```
   
5. **Create the database using Entity Framework Core:**
   
   ```
   dotnet ef database update
   ```
   
7. **Build and Run:**
   
   ```
   dotnet build
   dotnet run
   ```
   
9. **Open your web browser:**
    
   Navigate to https://localhost:7076 to access the application.
   


**Note:** Make sure you have [.NET Core SDK](https://dotnet.microsoft.com/en-us/download) installed on your system.
