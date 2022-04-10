using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AccountStageAndChoiceOfAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOfAccount",
                table: "AccountOwners",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AccountOpeningStages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bvn = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Stage = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOpeningStages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChoiceOfAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountType = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HasUtilityBill = table.Column<bool>(type: "bit", nullable: false),
                    HasValidId = table.Column<bool>(type: "bit", nullable: false),
                    Bvn = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChoiceOfAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOpeningStages");

            migrationBuilder.DropTable(
                name: "ChoiceOfAccounts");

            migrationBuilder.DropColumn(
                name: "TypeOfAccount",
                table: "AccountOwners");
        }
    }
}
