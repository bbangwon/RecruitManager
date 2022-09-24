using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitManager.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecruitSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoardNum = table.Column<int>(type: "int", nullable: false),
                    BoardTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    BoardContent = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GetDate()"),
                    StartDate = table.Column<DateTime>(type: "SmallDateTime", nullable: true),
                    EventDate = table.Column<DateTime>(type: "SmallDateTime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "SmallDateTime", nullable: true),
                    MaxCount = table.Column<int>(type: "int", nullable: false, defaultValue: 1000)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitSettings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruitSettings");
        }
    }
}
