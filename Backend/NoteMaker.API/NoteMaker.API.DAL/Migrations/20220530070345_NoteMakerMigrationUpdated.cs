using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteMaker.API.DAL.Migrations
{
    public partial class NoteMakerMigrationUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Starred",
                table: "Notes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Starred",
                table: "Notes");
        }
    }
}
