using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration_Form.Migrations
{
    public partial class alk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RePassword",
                table: "Users",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RePassword",
                table: "Users");
        }
    }
}
