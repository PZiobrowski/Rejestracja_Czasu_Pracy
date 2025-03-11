using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RCP.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identyfikator"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Imię"),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Nazwisko")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Breaks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identyfikator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Czas rozpoczęcia pracy"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Czas zakończenia pracy"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identyfikator użytkownika")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breaks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breaks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identyfikator")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Czas rozpoczęcia pracy"),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Czas zakończenia pracy"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Identyfikator użytkownika")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breaks_UserId",
                table: "Breaks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserId",
                table: "Works",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breaks");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
