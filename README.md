# Specification Pattern
The Specification Design Pattern encapsulates query logic like filtering, sorting, and includes into reusable objects. These objects define what data to retrieve, promoting clean, maintainable, and testable code. It's especially useful for dynamic queries, paging, and separating concerns in the data access layer.

This project uses the AdventureWorks SQL database as a data source and applies Entity Framework Core scaffolding to generate data models and a DbContext through reverse engineering. This approach simplifies database interaction by creating entity classes based on the existing schema, enabling efficient development and maintainable code with EF Core and LINQ. 


## [Scaffolding (Reverse Engineering)](https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding).
### install the following packages from NuGet:

* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

run the following command in the Package Manager Console: (Tools>Nuget Package Manager>Package Manager Console)
``` cs
Scaffold-DbContext "Data Source=.;Initial Catalog=AdventureWorksLT2022;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;" Microsoft.EntityFrameWorkCore.SqlServer -outputdir Repository/Models -context AdventureWorksDbContext -contextdir Repository -DataAnnotations -Force
```
You will find a new folder named Repository in your solution.


hint: You can remove DataAnnotations -force if you don't want annotations
