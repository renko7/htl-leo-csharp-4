using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuckNorrisDB.Migrations
{
    public partial class Categories2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryChuckNorrisFact",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    FactsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryChuckNorrisFact", x => new { x.CategoriesId, x.FactsId });
                    table.ForeignKey(
                        name: "FK_CategoryChuckNorrisFact_Category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryChuckNorrisFact_ChuckNorrisFacts_FactsId",
                        column: x => x.FactsId,
                        principalTable: "ChuckNorrisFacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryChuckNorrisFact_FactsId",
                table: "CategoryChuckNorrisFact",
                column: "FactsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryChuckNorrisFact");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
