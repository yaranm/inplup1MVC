using Microsoft.EntityFrameworkCore.Migrations;

namespace inplup1MVC.Migrations
{
    public partial class removedCatogireID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Produkter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Produkter",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
