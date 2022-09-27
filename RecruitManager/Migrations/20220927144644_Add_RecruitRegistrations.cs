using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecruitManager.Migrations
{
    public partial class Add_RecruitRegistrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecruitRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecruitSettingId = table.Column<int>(type: "int", nullable: true),
                    BoardName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BoardNum = table.Column<int>(type: "int", nullable: false),
                    BoardTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    CreationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GetDate()"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecruitRegistrations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecruitRegistrations");
        }
    }
}
