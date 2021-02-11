using Microsoft.EntityFrameworkCore.Migrations;

namespace inplup1MVC.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Produkter");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Produkter");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produkter",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Produkter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Produkter",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
