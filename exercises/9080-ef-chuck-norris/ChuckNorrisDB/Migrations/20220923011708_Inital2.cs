﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChuckNorrisDB.Migrations
{
    public partial class Inital2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuckNorrisFacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChuckNorrisId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Joke = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuckNorrisFacts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChuckNorrisFacts");
        }
    }
}
