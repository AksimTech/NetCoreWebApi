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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasData(new Owner[]
            {
                new Owner{Id = 1, Name = "Lucille B Johnson", Address = "137 Triple J Ranch Rd, Canon, GA, 30520", DateOfBirth = new DateTime(1990, 10, 21) },
                new Owner{Id = 2, Name = "Arlene R Smith", Address = "5916 Yeoman Way, Citrus Heights, CA, 95610", DateOfBirth = new DateTime(1988, 8, 19) }
            });

            modelBuilder.Entity<Account>().HasData(new Account[]
            {
                new Account{Id = 1, AccountType = "Domestic", DateCreated = DateTime.Now.Date, OwnerId = 1},
                new Account{Id = 2, AccountType = "Savings", DateCreated = DateTime.Now.Date.AddDays(-1), OwnerId = 2}
            });
        }
    }
}
