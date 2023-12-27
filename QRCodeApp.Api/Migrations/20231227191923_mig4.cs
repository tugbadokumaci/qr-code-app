using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRCodeApp.Api.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardDescription",
                table: "Cards",
                newName: "WebsiteUrl");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cards",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Cards",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Cards",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Cards",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Cards",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cards",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "WebsiteUrl",
                table: "Cards",
                newName: "CardDescription");
        }
    }
}
