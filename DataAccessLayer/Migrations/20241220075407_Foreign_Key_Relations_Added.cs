using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Foreign_Key_Relations_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Registers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegisterID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditCarts",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CartNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RegisterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCarts", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_CreditCarts_Registers_RegisterID",
                        column: x => x.RegisterID,
                        principalTable: "Registers",
                        principalColumn: "RegisterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registers_RoleId",
                table: "Registers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RegisterID",
                table: "Orders",
                column: "RegisterID");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCarts_RegisterID",
                table: "CreditCarts",
                column: "RegisterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Registers_RegisterID",
                table: "Orders",
                column: "RegisterID",
                principalTable: "Registers",
                principalColumn: "RegisterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registers_Roles_RoleId",
                table: "Registers",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Registers_RegisterID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Registers_Roles_RoleId",
                table: "Registers");

            migrationBuilder.DropTable(
                name: "CreditCarts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Registers_RoleId",
                table: "Registers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_RegisterID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Registers");

            migrationBuilder.DropColumn(
                name: "RegisterID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Orders");
        }
    }
}
