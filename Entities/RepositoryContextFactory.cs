using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;



namespace Entities
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Directory.GetCurrentDirectory() + "/../NetCoreWebApi.Api/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>();
            var connectionString = configuration["sqliteconnection:connectionString"];
            builder.UseSqlite(connectionString);
            return new RepositoryContext(builder.Options);
        }
    }
}
