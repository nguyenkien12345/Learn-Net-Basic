using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOfNguyenTrungKien.Migrations
{
    public partial class Add_Table_Categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CodeCategory",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CodeCategory = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CodeCategory);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CodeCategory",
                table: "Products",
                column: "CodeCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CodeCategory",
                table: "Products",
                column: "CodeCategory",
                principalTable: "Categories",
                principalColumn: "CodeCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CodeCategory",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CodeCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CodeCategory",
                table: "Products");
        }
    }
}
