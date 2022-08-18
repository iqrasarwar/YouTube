using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTube.Migrations
{
    public partial class modelsUpdated6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_channel_channelId",
                table: "user");

            migrationBuilder.AlterColumn<int>(
                name: "channelId",
                table: "user",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "channelId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_user_channel_channelId",
                table: "user",
                column: "channelId",
                principalTable: "channel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
