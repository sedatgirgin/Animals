using Microsoft.EntityFrameworkCore.Migrations;

namespace Animals.Migrations
{
    public partial class initialize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Reminder",
                newName: "Message");

            migrationBuilder.AddColumn<bool>(
                name: "IsUserDefined",
                table: "Reminder",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserDefined",
                table: "Reminder");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Reminder",
                newName: "Name");
        }
    }
}
