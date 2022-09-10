using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YouTube.Migrations
{
    public partial class modelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myExplore");

            migrationBuilder.AddColumn<string>(
                name: "Catagory",
                table: "myVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "myVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TimeLine",
                table: "myVideos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "myVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "channelId",
                table: "myVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Likes = table.Column<int>(type: "int", nullable: true),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subscribers = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    channelId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_channel_channelId",
                        column: x => x.channelId,
                        principalTable: "channel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likesCount = table.Column<int>(type: "int", nullable: false),
                    TimeLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    videoId = table.Column<int>(type: "int", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comments_myVideos_videoId",
                        column: x => x.videoId,
                        principalTable: "myVideos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_user_userID",
                        column: x => x.userID,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_myVideos_channelId",
                table: "myVideos",
                column: "channelId");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userID",
                table: "comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_videoId",
                table: "comments",
                column: "videoId");

            migrationBuilder.CreateIndex(
                name: "IX_user_channelId",
                table: "user",
                column: "channelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_myVideos_channel_channelId",
                table: "myVideos",
                column: "channelId",
                principalTable: "channel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_myVideos_channel_channelId",
                table: "myVideos");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "channel");

            migrationBuilder.DropIndex(
                name: "IX_myVideos_channelId",
                table: "myVideos");

            migrationBuilder.DropColumn(
                name: "Catagory",
                table: "myVideos");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "myVideos");

            migrationBuilder.DropColumn(
                name: "TimeLine",
                table: "myVideos");

            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "myVideos");

            migrationBuilder.DropColumn(
                name: "channelId",
                table: "myVideos");

            migrationBuilder.CreateTable(
                name: "myExplore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createdBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myExplore", x => x.Id);
                });
        }
    }
}
