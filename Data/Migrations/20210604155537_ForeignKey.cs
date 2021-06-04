using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FriendUserId",
                table: "InvitationsFriend",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvitationsFriend_FriendUserId",
                table: "InvitationsFriend",
                column: "FriendUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvitationsFriend_AspNetUsers_FriendUserId",
                table: "InvitationsFriend",
                column: "FriendUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvitationsFriend_AspNetUsers_FriendUserId",
                table: "InvitationsFriend");

            migrationBuilder.DropIndex(
                name: "IX_InvitationsFriend_FriendUserId",
                table: "InvitationsFriend");

            migrationBuilder.AlterColumn<string>(
                name: "FriendUserId",
                table: "InvitationsFriend",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
