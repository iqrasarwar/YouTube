using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTube.Migrations
{
    public partial class modelsUpdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_channel_userId",
                table: "channel");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImg",
                table: "user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "channelId",
                table: "user",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_channelId",
                table: "user",
                column: "channelId");

            migrationBuilder.CreateIndex(
                name: "IX_channel_userId",
                table: "channel",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_channel_channelId",
                table: "user",
                column: "channelId",
                principalTable: "channel",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_channel_channelId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_channelId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_channel_userId",
                table: "channel");

            migrationBuilder.DropColumn(
                name: "channelId",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImg",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_channel_userId",
                table: "channel",
                column: "userId",
                unique: true);
        }
    }
}
