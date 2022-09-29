using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTube.Migrations
{
    public partial class updateRelations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "channelId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "channel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "channelId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "channel");
        }
    }
}
