using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfSamurai.Data.Migrations
{
    public partial class MyFirstMigration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuoteTypeId",
                table: "Quotes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QuoteType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuoteType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_QuoteTypeId",
                table: "Quotes",
                column: "QuoteTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quotes_QuoteType_QuoteTypeId",
                table: "Quotes",
                column: "QuoteTypeId",
                principalTable: "QuoteType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quotes_QuoteType_QuoteTypeId",
                table: "Quotes");

            migrationBuilder.DropTable(
                name: "QuoteType");

            migrationBuilder.DropIndex(
                name: "IX_Quotes_QuoteTypeId",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "QuoteTypeId",
                table: "Quotes");
        }
    }
}
