using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class Edit_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Series",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalog", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Series_CatalogId",
                table: "Series",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CatalogId",
                table: "Movies",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogId",
                table: "Books",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Catalog_CatalogId",
                table: "Books",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Catalog_CatalogId",
                table: "Movies",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Series_Catalog_CatalogId",
                table: "Series",
                column: "CatalogId",
                principalTable: "Catalog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Catalog_CatalogId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Catalog_CatalogId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Series_Catalog_CatalogId",
                table: "Series");

            migrationBuilder.DropTable(
                name: "Catalog");

            migrationBuilder.DropIndex(
                name: "IX_Series_CatalogId",
                table: "Series");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CatalogId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Books_CatalogId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Books");
        }
    }
}
