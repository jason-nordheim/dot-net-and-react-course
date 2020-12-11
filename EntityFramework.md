# Entity Framework

-   Known as code first development methodology
-   Generated from a code base

## DotNetCli Tool 

Command: `dotnet tool install --global dotnet-ef`

## Database Context

-   Class: `DBContext`
-   Namespace: `Microsoft.EntityFrameworkCore`
-   Overview
    -   Used to represent a session with a database.
    -   Can be used to query and save instances of entities

### Creating a `DBContext`

1.  Define a new class that inherits from `DbContext`
2.  Create a constructor for that class that accepts a `DbContextOptions` object
3.  Pass the parameterized `DbContextOptions` to the base constructor

    ```cs
    public DataContext(DbContextOptions options): base(options)` { }
    ```

4.  Define the tables for the objects in the database.

    1.  Define the data model as a `.cs` class ( _if not already done elsewhere_ )
    2.  Create a method in the new class that returns a `DBSet<object>` ( _should replace `object`, with the type that entity framework should recreated in the database._ )

        ```cs
        /*
            represents a the data model → Values
            returns a DbSet of the desired `Type`
            method name = table name ( congenitally named the same as the object being returned )
        */
        public DbSet<Type> TableName { get; set; }
        ```

    3.  Add new service as a dependency in `API.startup.cs` file under the `ConfigureServices(IServiceCollection services)` method:

        1.  Add a new Service by calling the `services.AddDbContext<DbContext>` method

                ```cs
                /* inside startup.cs */
                public void ConfigureServices(IServiceCollection services)
                {
                    // setup DataContext to use Sqlite
                    services.AddDbContext<DataContext>( opt => {
                        opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                    });

                    services.AddControllers();
                }
                ```

            > `DbContext` represents the class created before that inherits from `DbContext`

        2.  Add `"DefaultConnection"` to API configuration file → `API/appsettings.json`

            ```json
            {
                "ConnectionString": {
                    "Default": "Data source=reactivities.db"
                },
                "Logging": {
                    "LogLevel": {
                        "Default": "Information",
                        "Microsoft": "Warning",
                        "Microsoft.Hosting.Lifetime": "Information"
                    }
                },
                "AllowedHosts": "*"
            }
            ```

        3.  Create a migration to scaffold out the database.
