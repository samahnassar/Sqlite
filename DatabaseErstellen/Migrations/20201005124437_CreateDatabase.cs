using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseErstellen.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurse",
                columns: table => new
                {
                    KuId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Datum = table.Column<DateTime>(nullable: false),
                    StuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurse", x => x.KuId);
                });

            migrationBuilder.CreateTable(
                name: "Studenten",
                columns: table => new
                {
                    StuId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Vorname = table.Column<string>(nullable: true),
                    KursKuId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenten", x => x.StuId);
                    table.ForeignKey(
                        name: "FK_Studenten_Kurse_KursKuId",
                        column: x => x.KursKuId,
                        principalTable: "Kurse",
                        principalColumn: "KuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Studenten_KursKuId",
                table: "Studenten",
                column: "KursKuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenten");

            migrationBuilder.DropTable(
                name: "Kurse");
        }
    }
}
