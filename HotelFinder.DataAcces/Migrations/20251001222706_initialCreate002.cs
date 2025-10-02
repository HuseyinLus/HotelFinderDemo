using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelFinder.DataAcces.Migrations
{
    public partial class initialCreate002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // LoginId kolonunu ekle
            migrationBuilder.AddColumn<int>(
                name: "LoginId",
                table: "RefreshTokens",
                type: "int",
                nullable: true);

            // Index oluştur
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_LoginId",
                table: "RefreshTokens",
                column: "LoginId");

            // Foreign key ekle
            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Logins_LoginId",
                table: "RefreshTokens",
                column: "LoginId",
                principalTable: "Logins",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Foreign key sil
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Logins_LoginId",
                table: "RefreshTokens");

            // Index sil
            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_LoginId",
                table: "RefreshTokens");

            // Kolonu sil
            migrationBuilder.DropColumn(
                name: "LoginId",
                table: "RefreshTokens");
        }
    }
}
