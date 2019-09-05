using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Entities
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBinder().SetBasePath(Directory.GetCurrentDirectory());
            return new RepositoryContext();
        }
    }
}
