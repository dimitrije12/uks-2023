﻿// <auto-generated />
using System;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240227232444_nova")]
    partial class nova
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Backend.Domain.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Backend.Domain.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("DeveloperId")
                        .HasColumnType("bigint");

                    b.Property<long>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<long>("PullRequestId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReactionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IssueId");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("ReactionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend.Domain.Models.Developer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Backend.Domain.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<long>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<long>("MilestoneId")
                        .HasColumnType("bigint");

                    b.Property<long>("PullRequestId")
                        .HasColumnType("bigint");

                    b.Property<long>("ReactionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("ReactionId");

                    b.ToTable("Events");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Backend.Domain.Models.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("MilestoneId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Backend.Domain.Models.Label", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long?>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("Backend.Domain.Models.Milestone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("Backend.Domain.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Visibility")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Backend.Domain.Models.PullRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("bigint");

                    b.Property<long>("SourceBranchId")
                        .HasColumnType("bigint");

                    b.Property<long>("TargetBranchId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SourceBranchId");

                    b.HasIndex("TargetBranchId");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("Backend.Domain.Models.Reaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<long?>("DeveloperId")
                        .HasColumnType("bigint");

                    b.Property<long?>("IssueId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PullRequestId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IssueId");

                    b.HasIndex("PullRequestId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("DeveloperIssue", b =>
                {
                    b.Property<long>("AssignedIssuesId")
                        .HasColumnType("bigint");

                    b.Property<long>("AssigneesId")
                        .HasColumnType("bigint");

                    b.HasKey("AssignedIssuesId", "AssigneesId");

                    b.HasIndex("AssigneesId");

                    b.ToTable("DeveloperIssue");
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.Property<long>("DevelopersId")
                        .HasColumnType("bigint");

                    b.Property<long>("StarredProjectsId")
                        .HasColumnType("bigint");

                    b.HasKey("DevelopersId", "StarredProjectsId");

                    b.HasIndex("StarredProjectsId");

                    b.ToTable("DeveloperProject");
                });

            modelBuilder.Entity("Backend.Domain.Models.CloseEvent", b =>
                {
                    b.HasBaseType("Backend.Domain.Models.Event");

                    b.HasDiscriminator().HasValue("CloseEvent");
                });

            modelBuilder.Entity("Backend.Domain.Models.CreateEvent", b =>
                {
                    b.HasBaseType("Backend.Domain.Models.Event");

                    b.HasDiscriminator().HasValue("CreateEvent");
                });

            modelBuilder.Entity("Backend.Domain.Models.DeleteEvent", b =>
                {
                    b.HasBaseType("Backend.Domain.Models.Event");

                    b.HasDiscriminator().HasValue("DeleteEvent");
                });

            modelBuilder.Entity("Backend.Domain.Models.OpenEvent", b =>
                {
                    b.HasBaseType("Backend.Domain.Models.Event");

                    b.HasDiscriminator().HasValue("OpenEvent");
                });

            modelBuilder.Entity("Backend.Domain.Models.UpdateEvent", b =>
                {
                    b.HasBaseType("Backend.Domain.Models.Event");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NewContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OldContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("UpdateEvent");
                });

            modelBuilder.Entity("Backend.Domain.Models.Comment", b =>
                {
                    b.HasOne("Backend.Domain.Models.Developer", "Developer")
                        .WithMany("Comments")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.PullRequest", "PullRequest")
                        .WithMany("Comments")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Reaction", "Reaction")
                        .WithMany("Comments")
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Issue");

                    b.Navigation("PullRequest");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Backend.Domain.Models.Event", b =>
                {
                    b.HasOne("Backend.Domain.Models.Issue", "Issue")
                        .WithMany("Events")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Milestone", "Milestone")
                        .WithMany("Events")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.PullRequest", "PullRequest")
                        .WithMany("Events")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Reaction", "Reaction")
                        .WithMany("Events")
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Milestone");

                    b.Navigation("PullRequest");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Backend.Domain.Models.Issue", b =>
                {
                    b.HasOne("Backend.Domain.Models.Developer", "Creator")
                        .WithMany("createdIssues")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Project", null)
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Creator");

                    b.Navigation("Milestone");
                });

            modelBuilder.Entity("Backend.Domain.Models.Label", b =>
                {
                    b.HasOne("Backend.Domain.Models.Issue", null)
                        .WithMany("Labels")
                        .HasForeignKey("IssueId");
                });

            modelBuilder.Entity("Backend.Domain.Models.Milestone", b =>
                {
                    b.HasOne("Backend.Domain.Models.Project", "Project")
                        .WithMany("Milestones")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Backend.Domain.Models.PullRequest", b =>
                {
                    b.HasOne("Backend.Domain.Models.Project", null)
                        .WithMany("PullRequests")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Backend.Domain.Models.Branch", "SourceBranch")
                        .WithMany()
                        .HasForeignKey("SourceBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Branch", "TargetBranch")
                        .WithMany()
                        .HasForeignKey("TargetBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceBranch");

                    b.Navigation("TargetBranch");
                });

            modelBuilder.Entity("Backend.Domain.Models.Reaction", b =>
                {
                    b.HasOne("Backend.Domain.Models.Developer", null)
                        .WithMany("Reactions")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Backend.Domain.Models.Issue", null)
                        .WithMany("Reactions")
                        .HasForeignKey("IssueId");

                    b.HasOne("Backend.Domain.Models.PullRequest", null)
                        .WithMany("Reactions")
                        .HasForeignKey("PullRequestId");
                });

            modelBuilder.Entity("DeveloperIssue", b =>
                {
                    b.HasOne("Backend.Domain.Models.Issue", null)
                        .WithMany()
                        .HasForeignKey("AssignedIssuesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Developer", null)
                        .WithMany()
                        .HasForeignKey("AssigneesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.HasOne("Backend.Domain.Models.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Domain.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("StarredProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Domain.Models.Developer", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Reactions");

                    b.Navigation("createdIssues");
                });

            modelBuilder.Entity("Backend.Domain.Models.Issue", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");

                    b.Navigation("Labels");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Backend.Domain.Models.Milestone", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Backend.Domain.Models.Project", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Milestones");

                    b.Navigation("PullRequests");
                });

            modelBuilder.Entity("Backend.Domain.Models.PullRequest", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Backend.Domain.Models.Reaction", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
