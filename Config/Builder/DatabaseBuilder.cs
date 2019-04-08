using System;
using System.Reflection;
using DatabaseFactory.Config.Exceptions;
using DatabaseFactory.Data.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseFactory.Config.Builder
{
    public sealed class DatabaseBuilder : IDatabaseBuilder, IDatabaseBuild
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private DatabaseOptions _databaseOptions;

        public IDatabaseBuild BuildWithOptions(Func<IDatabaseOptionsBuilder, DatabaseOptions> buildDatabaseOptions)
        {
            var builder = DatabaseOptionsBuilder.CreateInstance();

            _databaseOptions = buildDatabaseOptions(builder);

            return this;
        }

        public IDatabase Build()
        {
            if (!typeof(IDatabase).IsAssignableFrom(_databaseOptions.contextType))
            {
                throw new DatabaseTypeMismatchException(_databaseOptions.contextType, typeof(IDatabase));
            }

            _serviceCollection.AddDatabase(_databaseOptions.contextType, _databaseOptions);

            var serviceProvider = _serviceCollection.BuildServiceProvider();

            var client = serviceProvider.GetService<IDatabase>();

            return client;
        }
    }


}
