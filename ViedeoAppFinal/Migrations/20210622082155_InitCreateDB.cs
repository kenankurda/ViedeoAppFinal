﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViedeoAppFinal.Migrations
{
    public partial class InitCreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DayOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActorVideo",
                columns: table => new
                {
                    ActorsActorId = table.Column<int>(type: "int", nullable: false),
                    VideosVideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorVideo", x => new { x.ActorsActorId, x.VideosVideoId });
                    table.ForeignKey(
                        name: "FK_ActorVideo_Actors_ActorsActorId",
                        column: x => x.ActorsActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorVideo_Videos_VideosVideoId",
                        column: x => x.VideosVideoId,
                        principalTable: "Videos",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "ActorId", "DayOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1970, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenan", "Kurda" },
                    { 2, new DateTime(1956, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrison", "Ford" },
                    { 3, new DateTime(1945, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antony", "Hopkins" },
                    { 4, new DateTime(1980, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johny", "Dep" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Action-Comedy" },
                    { 4, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "GenreId", "Name" },
                values: new object[] { 1, 1, "Indiana Johnes" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "GenreId", "Name" },
                values: new object[] { 2, 1, "Call of wild" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "VideoId", "GenreId", "Name" },
                values: new object[] { 3, 3, "Pirates of the Caribean" });

            migrationBuilder.CreateIndex(
                name: "IX_ActorVideo_VideosVideoId",
                table: "ActorVideo",
                column: "VideosVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GenreId",
                table: "Videos",
                column: "GenreId");


            migrationBuilder.InsertData(
                table: "ActorVideo",
                columns: new[] { "ActorsActorId", "VideosVideoId" },
                values: new object[,]
                {
                    {1, 1 },
                    {2, 2 },
                    {3, 1 }
                });
                
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorVideo");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
