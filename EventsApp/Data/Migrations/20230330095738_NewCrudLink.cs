using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventsApp.Data.Migrations
{
    public partial class NewCrudLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Events");
        }
    }
}
