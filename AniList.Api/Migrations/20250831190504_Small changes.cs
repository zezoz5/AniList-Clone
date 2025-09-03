using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AniList.Api.Migrations
{
    /// <inheritdoc />
    public partial class Smallchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUsers_Animes_AnimeId",
                table: "AnimeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUsers_Users_UserId",
                table: "AnimeUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaUsers_Mangas_MangaId",
                table: "MangaUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_MangaUsers_Users_UserId",
                table: "MangaUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MangaUsers",
                table: "MangaUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimeUsers",
                table: "AnimeUsers");

            migrationBuilder.RenameTable(
                name: "MangaUsers",
                newName: "UserMangas");

            migrationBuilder.RenameTable(
                name: "AnimeUsers",
                newName: "UserAnimes");

            migrationBuilder.RenameIndex(
                name: "IX_MangaUsers_UserId",
                table: "UserMangas",
                newName: "IX_UserMangas_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AnimeUsers_UserId",
                table: "UserAnimes",
                newName: "IX_UserAnimes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMangas",
                table: "UserMangas",
                columns: new[] { "MangaId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnimes",
                table: "UserAnimes",
                columns: new[] { "AnimeId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimes_Animes_AnimeId",
                table: "UserAnimes",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnimes_Users_UserId",
                table: "UserAnimes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangas_Mangas_MangaId",
                table: "UserMangas",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMangas_Users_UserId",
                table: "UserMangas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimes_Animes_AnimeId",
                table: "UserAnimes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnimes_Users_UserId",
                table: "UserAnimes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMangas_Mangas_MangaId",
                table: "UserMangas");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMangas_Users_UserId",
                table: "UserMangas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMangas",
                table: "UserMangas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnimes",
                table: "UserAnimes");

            migrationBuilder.RenameTable(
                name: "UserMangas",
                newName: "MangaUsers");

            migrationBuilder.RenameTable(
                name: "UserAnimes",
                newName: "AnimeUsers");

            migrationBuilder.RenameIndex(
                name: "IX_UserMangas_UserId",
                table: "MangaUsers",
                newName: "IX_MangaUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAnimes_UserId",
                table: "AnimeUsers",
                newName: "IX_AnimeUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MangaUsers",
                table: "MangaUsers",
                columns: new[] { "MangaId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimeUsers",
                table: "AnimeUsers",
                columns: new[] { "AnimeId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUsers_Animes_AnimeId",
                table: "AnimeUsers",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUsers_Users_UserId",
                table: "AnimeUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaUsers_Mangas_MangaId",
                table: "MangaUsers",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MangaUsers_Users_UserId",
                table: "MangaUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
