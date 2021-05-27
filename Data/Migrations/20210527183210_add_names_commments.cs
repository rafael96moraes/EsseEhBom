using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class add_names_commments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CommentsSerie",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "CommentsBook",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CommentsSerie");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "CommentsBook");
        }
    }
}
