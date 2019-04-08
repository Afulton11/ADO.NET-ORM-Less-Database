using System;
namespace DatabaseFactory.Config.Builder
{
    public interface IDatabaseBuilder
    {
        IDatabaseBuild BuildWithOptions(Func<IDatabaseOptionsBuilder, DatabaseOptions> buildDatabaseOptions);
    }

    public interface IDatabaseBuild
    {
        Data.Contracts.IDatabase Build();
    }
}
