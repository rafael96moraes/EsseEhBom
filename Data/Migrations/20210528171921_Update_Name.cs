using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class Update_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "CommentsSerie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "CommentsMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "CommentsBook",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "CommentsSerie");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "CommentsMovie");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "CommentsBook");
        }
    }
}
