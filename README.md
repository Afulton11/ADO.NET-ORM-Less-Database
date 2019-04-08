# ADO.NET-ORM-Less-Database
A ORM-Less library based off of EF Core's DbContext. Made for use in ASP.NET Core application, but could be used in any .Net application.

## Utilizing .Net Core's Dependency Injection
```C#
        public void ConfigureServices(IServiceCollection services)
        {
            ...
            
            // Create a SQLiteDatabase that can be injected into any constructor.
            services.AddDatabase<SQLiteDatabase>((provider, options) =>
            {
                options.UseSqliteDataSource("some/path/to/sqlite.db");
            });
            
            // Create 
            
            ...
        }
```

While there is a built in `SQLiteDatabase` and `SQLDatabase` You may extend those or create a new custom Database altogether by extending `Database`
