using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectOfNguyenTrungKien.Migrations
{
    public partial class Alter_Table_Products_And_Categories_Add_Field_Date_Created_Time_Created_Date_Updated_Time_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Date_Created",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date_Updated",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time_Created",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time_Updated",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date_Created",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Date_Updated",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time_Created",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time_Updated",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Date_Updated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Time_Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Time_Updated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Date_Created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Date_Updated",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Time_Created",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Time_Updated",
                table: "Categories");
        }
    }
}
