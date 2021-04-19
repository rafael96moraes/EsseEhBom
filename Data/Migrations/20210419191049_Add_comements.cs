using Microsoft.EntityFrameworkCore.Migrations;

namespace EsseEhBom.Data.Migrations
{
    public partial class Add_comements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "MainCastSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastSeries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MainCastMovies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastMovies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogId = table.Column<int>(type: "int", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Catalog_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainCastSeries_ActorId",
                table: "MainCastSeries",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCastSeries_SerieId",
                table: "MainCastSeries",
                column: "SerieId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCastMovies_ActorId",
                table: "MainCastMovies",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_MainCastMovies_MovieId",
                table: "MainCastMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CatalogId",
                table: "Comments",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Actors_ActorId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastMovies_Movies_MovieId",
                table: "MainCastMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Actors_ActorId",
                table: "MainCastSeries");

            migrationBuilder.DropForeignKey(
                name: "FK_MainCastSeries_Series_SerieId",
                table: "MainCastSeries");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_MainCastSeries_ActorId",
                table: "MainCastSeries");

            migrationBuilder.DropIndex(
                name: "IX_MainCastSeries_SerieId",
                table: "MainCastSeries");

            migrationBuilder.DropIndex(
                name: "IX_MainCastMovies_ActorId",
                table: "MainCastMovies");

            migrationBuilder.DropIndex(
                name: "IX_MainCastMovies_MovieId",
                table: "MainCastMovies");

            migrationBuilder.AlterColumn<int>(
                name: "SerieId",
                table: "MainCastSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "MainCastMovies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActorId",
                table: "MainCastMovies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
