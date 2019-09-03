using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //    optionsBuilder.UseSqlite("Data Source=../Database/database.db");
        // }

        // protected override void OnModelCreating(ModelBuilder builder){
        //     base.OnModelCreating(builder);
        // }
    }
}
