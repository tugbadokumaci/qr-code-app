using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class SavedCardsAdded1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedCards_UserModel_UserId",
                table: "SavedCards");

            migrationBuilder.DropIndex(
                name: "IX_SavedCards_UserId",
                table: "SavedCards");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "SavedCards",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "SavedCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SavedCards_UserId1",
                table: "SavedCards",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCards_UserModel_UserId1",
                table: "SavedCards",
                column: "UserId1",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SavedCards_UserModel_UserId1",
                table: "SavedCards");

            migrationBuilder.DropIndex(
                name: "IX_SavedCards_UserId1",
                table: "SavedCards");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "SavedCards");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "SavedCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_SavedCards_UserId",
                table: "SavedCards",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SavedCards_UserModel_UserId",
                table: "SavedCards",
                column: "UserId",
                principalTable: "UserModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
