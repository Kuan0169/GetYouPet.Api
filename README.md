# GetYouPet API
  ## 1.Project description.
  A RESTful API for managing pet information, built with **ASP.NET Core** and **Entity Framework Core**. 
  Features include:
  - CRUD operations for pets
  - Separation of concerns with `Services` and `Data` layers
  - Unit testing with **xUnit** (SQL Server)
  
  ## 2.Build/run instructions.
    ### Prerequisites
    - .NET 7 SDK or Higher
    - SQL Server (for production/testing with real database)
    ### Steps
      1.**Clone Repository**
      git clone https://github.com/Kuan0169/GetYouPet.git
      
      2.**Configure Database Connection**
      Update connection string in appsettings.json:
      "ConnectionStrings": {
      "Default": "Server=your_server;Database=GetYouPet;User Id=user;Password=pass;TrustServerCertificate=True"
      }
      
      3. **Apply Database Migrations**
      dotnet ef database update --project GetYouPet.Data
    
      4.**Run API**
      dotnet run --project GetYouPet.API
  
  ## 3.How to run unit tests.
    SQL Server Tests (Requires active database)
    dotnet test GetYouPet.Tests --filter "Category=SqlServer"
  
  
  ## 4.Any assumptions or design decisions.
