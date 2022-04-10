using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountOwnerAddresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    StreetNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Lgt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwnerAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountOwners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DateOfBirth = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Purpose = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    SourceOfFund = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PreferredBranch = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmploymentStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Occupation = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployerAddress = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    EmploymentDate = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fatcas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    USResident = table.Column<bool>(type: "bit", nullable: false),
                    USCitizen = table.Column<bool>(type: "bit", nullable: false),
                    USGreenCard = table.Column<bool>(type: "bit", nullable: false),
                    OECDResident = table.Column<bool>(type: "bit", nullable: false),
                    OECDControlling = table.Column<bool>(type: "bit", nullable: false),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NextOfKins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoKSurname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NokFirstname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NokOthernames = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NokDateOfBirth = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NokRelationship = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bvn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextOfKins", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOwnerAddresses");

            migrationBuilder.DropTable(
                name: "AccountOwners");

            migrationBuilder.DropTable(
                name: "AccountReasons");

            migrationBuilder.DropTable(
                name: "Employments");

            migrationBuilder.DropTable(
                name: "Fatcas");

            migrationBuilder.DropTable(
                name: "NextOfKins");
        }
    }
}
