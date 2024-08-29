### The dotnet-ef tool must be install to use the database command
```bash
dotnet tool install --global dotnet-ef
```

### Migration
```bash
dotnet ef migrations add "initial ApplicationDbContext" --project Persistence --startup-project API --output-dir Migrations --context ApplicationDbContext

dotnet ef migrations add "initial AuthDbContext" --project Persistence --startup-project API --output-dir Migrations --context AuthDbContext

dotnet ef database update --project Persistence --startup-project API --context ApplicationDbContext

dotnet ef database update --project Persistence --startup-project API --context AuthDbContext
```

### Add reference from the project 'Application' to the project 'API'
```bash
cd API
dotnet add reference ..\Application\ 
```

### Run
```bash
dotnet restore #Restore nuget packages
dotnet build #Build a project
dotnet watch run -p API #Run the project with hot reload
```

### dotnet add package <PACKAGE_NAME> #install a NuGet package
```bash
#For example, to install the Newtonsoft.Json package, 
#use the following command
dotnet add package Newtonsoft.Json
```

### database connection string
```bash
"bootcampDatabase": "Server=localhost,1433;Database=bootcamp;User Id=sa;Password=StrongPassword123;TrustServerCertificate=True;e"
```
