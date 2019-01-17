using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Samurais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rank",
                table: "Samurais",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Weapon",
                table: "Samurais",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Samurais");

            migrationBuilder.DropColumn(
                name: "Weapon",
                table: "Samurais");
        }
    }
}
