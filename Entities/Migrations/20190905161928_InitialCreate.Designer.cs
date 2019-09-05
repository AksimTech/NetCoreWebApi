﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20190905161928_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Entities.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountType")
                        .IsRequired();

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("OwnerId");

                    b.HasKey("Id");

                    b.ToTable("account");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = "Domestic",
                            DateCreated = new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Local),
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountType = "Savings",
                            DateCreated = new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Local),
                            OwnerId = 2
                        });
                });

            modelBuilder.Entity("Entities.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("owner");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "137 Triple J Ranch Rd, Canon, GA, 30520",
                            DateOfBirth = new DateTime(1990, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Lucille B Johnson"
                        },
                        new
                        {
                            Id = 2,
                            Address = "5916 Yeoman Way, Citrus Heights, CA, 95610",
                            DateOfBirth = new DateTime(1988, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Arlene R Smith"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
