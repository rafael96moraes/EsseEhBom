using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class update_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonNumber",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Series",
                newName: "Release");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Movies",
                newName: "Release");

            migrationBuilder.RenameColumn(
                name: "ReleaseYear",
                table: "Books",
                newName: "ReleaseRelease");

            migrationBuilder.AddColumn<int>(
                name: "SeasonNumber",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeasonNumber",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "Release",
                table: "Series",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "Release",
                table: "Movies",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "ReleaseRelease",
                table: "Books",
                newName: "ReleaseYear");

            migrationBuilder.AddColumn<int>(
                name: "SeasonNumber",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
