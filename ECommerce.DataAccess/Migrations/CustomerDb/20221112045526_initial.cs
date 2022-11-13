using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.DataAccess.Migrations.CustomerDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Orders = table.Column<int>(type: "int", nullable: false),
                    LastOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
