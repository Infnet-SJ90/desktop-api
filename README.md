# Scheduling-api
API for scheduling management

# Technologies
The project uses asp net core 2.0 to make the api operations, entity framework core to do database operations and xUnit for tests.

# How to run
Clone the project
```
git clone https://github.com/Infnet-SJ90/scheduling-api
```

Open the solution in visual studio.
If the debug environment is configured, then the API will start running on an instance of IIS express. Set the environment to release and it will run as a self-hosted windows service using kestrel(ASP net core Web server).

The solution is configured, by default, to use an in-memory database.
To use a pre existent instance of a database, you should configure the Default connection string in the appsettings.json

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=Database;User ID=DatabaseUser; Password=DatabasePassword"
  },  
}
```

and should comment line 56 and uncomment line 55 on class Startup.cs
```
//services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase());
```

# Using
After the service is running, you can make all the operations available on the API via Swagger. To do this you must access this address via browser: 
```
http://localhost:63818/swagger
```