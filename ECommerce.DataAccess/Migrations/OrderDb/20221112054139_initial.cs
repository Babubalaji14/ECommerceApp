using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceApp.DataAccess.Migrations.OrderDb
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingName = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nVarchar(25)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
