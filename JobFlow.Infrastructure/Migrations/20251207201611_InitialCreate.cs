using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Position = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    LinkedInUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    WayOfApplication = table.Column<string>(type: "TEXT", nullable: false),
                    Website = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Contact = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Compatibility = table.Column<int>(type: "INTEGER", nullable: false),
                    CompatibilityReason = table.Column<string>(type: "TEXT", nullable: false),
                    JobRelatedDocs = table.Column<string>(type: "TEXT", nullable: false),
                    LastInteractionDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastInteractionNote = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
