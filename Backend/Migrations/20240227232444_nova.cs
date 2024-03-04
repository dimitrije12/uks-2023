using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Developers_DeveloperId",
                table: "Issues");

            migrationBuilder.DropIndex(
                name: "IX_Issues_DeveloperId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Issues");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Issues",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorId",
                table: "Issues",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Issues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Issues",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DeveloperIssue",
                columns: table => new
                {
                    AssignedIssuesId = table.Column<long>(type: "bigint", nullable: false),
                    AssigneesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperIssue", x => new { x.AssignedIssuesId, x.AssigneesId });
                    table.ForeignKey(
                        name: "FK_DeveloperIssue_Developers_AssigneesId",
                        column: x => x.AssigneesId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperIssue_Issues_AssignedIssuesId",
                        column: x => x.AssignedIssuesId,
                        principalTable: "Issues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Label_Issues_IssueId",
                        column: x => x.IssueId,
                        principalTable: "Issues",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Issues_CreatorId",
                table: "Issues",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperIssue_AssigneesId",
                table: "DeveloperIssue",
                column: "AssigneesId");

            migrationBuilder.CreateIndex(
                name: "IX_Label_IssueId",
                table: "Label",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Developers_CreatorId",
                table: "Issues",
                column: "CreatorId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Issues_Developers_CreatorId",
                table: "Issues");

            migrationBuilder.DropTable(
                name: "DeveloperIssue");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropIndex(
                name: "IX_Issues_CreatorId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Issues");

            migrationBuilder.AddColumn<long>(
                name: "DeveloperId",
                table: "Issues",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issues_DeveloperId",
                table: "Issues",
                column: "DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Issues_Developers_DeveloperId",
                table: "Issues",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id");
        }
    }
}
