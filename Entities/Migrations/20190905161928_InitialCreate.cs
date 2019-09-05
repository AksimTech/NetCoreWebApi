using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { 1, "Domestic", new DateTime(2019, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { 2, "Savings", new DateTime(2019, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), 2 });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { 1, "137 Triple J Ranch Rd, Canon, GA, 30520", new DateTime(1990, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucille B Johnson" });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { 2, "5916 Yeoman Way, Citrus Heights, CA, 95610", new DateTime(1988, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arlene R Smith" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
