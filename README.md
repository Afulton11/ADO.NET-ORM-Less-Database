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
            
            ...
        }
```

While there is a built in `SQLiteDatabase` and `SQLDatabase` You may extend those or create a new custom Database altogether by extending `Database`

Database queries and commands
===
The ORM-Less Database uses Command-Query separation. This architecture is described incredibly well in [This Article On Commands](https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-command-side-of-my-architecture/) and [This Article On Queries](https://blogs.cuttingedge.it/steven/posts/2011/meanwhile-on-the-query-side-of-my-architecture/). Both of articles are written by Steven van Deursen on his blog.

### Commands
TODO: Write Description
### Queries
TODO: Write Description
