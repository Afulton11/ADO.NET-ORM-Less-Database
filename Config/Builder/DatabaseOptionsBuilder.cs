﻿using DatabaseFactory.Data;
using EnsureThat;
using Microsoft.Data.Sqlite;

namespace DatabaseFactory.Config.Builder
{
    public sealed class DatabaseOptionsBuilder<TContext> :
        IDatabaseOptionsBuilder
        where TContext : Database
    {

        /// <summary>
        /// Creates a new instance of the <see cref="DatabaseOptionsBuilder{TContext}"/>class for building <see cref="DatabaseOptions{TContext}"/>
        /// </summary>
        /// <returns>The instance.</returns>
        public static DatabaseOptionsBuilder<TContext> CreateInstance()
            => new DatabaseOptionsBuilder<TContext>();

        private DatabaseOptionsBuilder() {}


        public void UseSqliteDataSource(string dataSource)
        {
            EnsureArg.IsNotNullOrWhiteSpace(dataSource);

            var connectionStringBuilder = new SqliteConnectionStringBuilder
            {
                DataSource = dataSource
            };
            Options.ConnectionString = connectionStringBuilder.ConnectionString;

        }

        public void UseConnectionString(string connectionString)
        {
            EnsureArg.IsNotEmptyOrWhitespace(connectionString);

            Options.ConnectionString = connectionString;
        }

        public DatabaseOptions<TContext> Options { get; } = new DatabaseOptions<TContext>();
    }
}
