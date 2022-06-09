1- please make sure to run project in vs 2022 .NET 6 SDK
   you need to run the backend project from "AIHR/WorkloadCalculator/WorkloadCalculator.sln"
   the project will run using "https://localhost:7194" 
   you can navigate to "https://localhost:7194/api" to check the endpoints from swagger.
   
2- run the ng serve for angular project from  "workload-calc" 
   if the backend port changed please update it in "workload-calc\src\app\api.service.ts"
   line 9 'SERVER_URL = "https://localhost:7194/api";'

3- i configured the application to use an in-memory database by default. 
   This ensures that you can run the solution without needing to set up SQL Server.
   If you would like to use SQL Server, you will need to update 
   "AIHR/WorkloadCalculator/appsettings.json" as follows:
  "UseInMemoryDatabase": false,
   "ConnectionStrings": {
    "DefaultConnection": "your Connection Strings"
  }
4- integration test as well is configured to use in-memory db 
   if you want to use it with sql server db 
   update "Application.IntegerationTests/appsettings.json"
   "UseInMemoryDatabase": false,
   "ConnectionStrings": {
    "DefaultConnection": "your Connection Strings"
  }
5- for this task i used 
   -CleanArchitecture
   -mediatR, 
   -CQRS, 
   -Entity framework core 6,
   -.net 6
   -angular 
   -nunit(for unit test and integration test).
6- inside solarSystem folder you can find another readme file for second task Details