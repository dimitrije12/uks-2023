using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    Comment_IssueId = table.Column<long>(type: "INTEGER", nullable: true),
                    Comment_PullRequestId = table.Column<long>(type: "INTEGER", nullable: true),
                    DeveloperId = table.Column<long>(type: "INTEGER", nullable: true),
                    Comment_ReactionId = table.Column<long>(type: "INTEGER", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MilestoneId = table.Column<long>(type: "INTEGER", nullable: true),
                    IssueId = table.Column<long>(type: "INTEGER", nullable: true),
                    PullRequestId = table.Column<long>(type: "INTEGER", nullable: true),
                    ReactionId = table.Column<long>(type: "INTEGER", nullable: true),
                    FieldName = table.Column<string>(type: "TEXT", nullable: true),
                    OldContent = table.Column<string>(type: "TEXT", nullable: true),
                    NewContent = table.Column<string>(type: "TEXT", nullable: true),
                    Issue_MilestoneId = table.Column<long>(type: "INTEGER", nullable: true),
                    Issue_DeveloperId = table.Column<long>(type: "INTEGER", nullable: true),
                    ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Milestone_ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    Project_Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    License = table.Column<string>(type: "TEXT", nullable: true),
                    Visibility = table.Column<int>(type: "INTEGER", nullable: true),
                    SourceBranchId = table.Column<long>(type: "INTEGER", nullable: true),
                    TargetBranchId = table.Column<long>(type: "INTEGER", nullable: true),
                    PullRequest_ProjectId = table.Column<long>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    Reaction_DeveloperId = table.Column<long>(type: "INTEGER", nullable: true),
                    Reaction_IssueId = table.Column<long>(type: "INTEGER", nullable: true),
                    Reaction_PullRequestId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Comment_IssueId",
                        column: x => x.Comment_IssueId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Comment_PullRequestId",
                        column: x => x.Comment_PullRequestId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Comment_ReactionId",
                        column: x => x.Comment_ReactionId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_IssueId",
                        column: x => x.IssueId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Issue_DeveloperId",
                        column: x => x.Issue_DeveloperId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Issue_MilestoneId",
                        column: x => x.Issue_MilestoneId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Milestone_ProjectId",
                        column: x => x.Milestone_ProjectId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_PullRequestId",
                        column: x => x.PullRequestId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_PullRequest_ProjectId",
                        column: x => x.PullRequest_ProjectId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ReactionId",
                        column: x => x.ReactionId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reaction_DeveloperId",
                        column: x => x.Reaction_DeveloperId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reaction_IssueId",
                        column: x => x.Reaction_IssueId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reaction_PullRequestId",
                        column: x => x.Reaction_PullRequestId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_SourceBranchId",
                        column: x => x.SourceBranchId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_TargetBranchId",
                        column: x => x.TargetBranchId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperProject",
                columns: table => new
                {
                    DevelopersId = table.Column<long>(type: "INTEGER", nullable: false),
                    StarredProjectsId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperProject", x => new { x.DevelopersId, x.StarredProjectsId });
                    table.ForeignKey(
                        name: "FK_DeveloperProject_BaseEntity_DevelopersId",
                        column: x => x.DevelopersId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperProject_BaseEntity_StarredProjectsId",
                        column: x => x.StarredProjectsId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Comment_IssueId",
                table: "BaseEntity",
                column: "Comment_IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Comment_PullRequestId",
                table: "BaseEntity",
                column: "Comment_PullRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Comment_ReactionId",
                table: "BaseEntity",
                column: "Comment_ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_DeveloperId",
                table: "BaseEntity",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_IssueId",
                table: "BaseEntity",
                column: "IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Issue_DeveloperId",
                table: "BaseEntity",
                column: "Issue_DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Issue_MilestoneId",
                table: "BaseEntity",
                column: "Issue_MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_MilestoneId",
                table: "BaseEntity",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Milestone_ProjectId",
                table: "BaseEntity",
                column: "Milestone_ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ProjectId",
                table: "BaseEntity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PullRequestId",
                table: "BaseEntity",
                column: "PullRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PullRequest_ProjectId",
                table: "BaseEntity",
                column: "PullRequest_ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ReactionId",
                table: "BaseEntity",
                column: "ReactionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reaction_DeveloperId",
                table: "BaseEntity",
                column: "Reaction_DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reaction_IssueId",
                table: "BaseEntity",
                column: "Reaction_IssueId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reaction_PullRequestId",
                table: "BaseEntity",
                column: "Reaction_PullRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_SourceBranchId",
                table: "BaseEntity",
                column: "SourceBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_TargetBranchId",
                table: "BaseEntity",
                column: "TargetBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Username",
                table: "BaseEntity",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperProject_StarredProjectsId",
                table: "DeveloperProject",
                column: "StarredProjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperProject");

            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
