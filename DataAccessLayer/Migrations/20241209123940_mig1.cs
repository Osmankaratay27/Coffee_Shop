using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeMenus",
                columns: table => new
                {
                    CoffeeMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoffeeMenuPrice = table.Column<double>(type: "float", nullable: false),
                    CoffeeMenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoffeeMenuUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoffeeMenuCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeMenus", x => x.CoffeeMenuId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    LoginID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.LoginID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderPrice = table.Column<double>(type: "float", nullable: false),
                    OrderUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeMenus");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
