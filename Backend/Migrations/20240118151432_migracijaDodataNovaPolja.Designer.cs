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
    [Migration("20240118151432_migracijaDodataNovaPolja")]
    partial class migracijaDodataNovaPolja
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Backend.Models.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Backend.Models.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IssueId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PullRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReactionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IssueId");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("ReactionId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Backend.Models.Developer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Developers");
                });

            modelBuilder.Entity("Backend.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<long>("IssueId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MilestoneId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("PullRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("ReactionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Time")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("PullRequestId");

                    b.HasIndex("ReactionId");

                    b.ToTable("Events");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Backend.Models.Issue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MilestoneId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("MilestoneId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Backend.Models.Milestone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Milestones");
                });

            modelBuilder.Entity("Backend.Models.Project", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("License")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Visibility")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Backend.Models.PullRequest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SourceBranchId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("TargetBranchId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("SourceBranchId");

                    b.HasIndex("TargetBranchId");

                    b.ToTable("PullRequests");
                });

            modelBuilder.Entity("Backend.Models.Reaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IssueId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PullRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperId");

                    b.HasIndex("IssueId");

                    b.HasIndex("PullRequestId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.Property<long>("DevelopersId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("StarredProjectsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DevelopersId", "StarredProjectsId");

                    b.HasIndex("StarredProjectsId");

                    b.ToTable("DeveloperProject");
                });

            modelBuilder.Entity("Backend.Models.CloseEvent", b =>
                {
                    b.HasBaseType("Backend.Models.Event");

                    b.HasDiscriminator().HasValue("CloseEvent");
                });

            modelBuilder.Entity("Backend.Models.CreateEvent", b =>
                {
                    b.HasBaseType("Backend.Models.Event");

                    b.HasDiscriminator().HasValue("CreateEvent");
                });

            modelBuilder.Entity("Backend.Models.DeleteEvent", b =>
                {
                    b.HasBaseType("Backend.Models.Event");

                    b.HasDiscriminator().HasValue("DeleteEvent");
                });

            modelBuilder.Entity("Backend.Models.OpenEvent", b =>
                {
                    b.HasBaseType("Backend.Models.Event");

                    b.HasDiscriminator().HasValue("OpenEvent");
                });

            modelBuilder.Entity("Backend.Models.UpdateEvent", b =>
                {
                    b.HasBaseType("Backend.Models.Event");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NewContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OldContent")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("UpdateEvent");
                });

            modelBuilder.Entity("Backend.Models.Comment", b =>
                {
                    b.HasOne("Backend.Models.Developer", "Developer")
                        .WithMany("Comments")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Issue", "Issue")
                        .WithMany("Comments")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.PullRequest", "PullRequest")
                        .WithMany("Comments")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Reaction", "Reaction")
                        .WithMany("Comments")
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Issue");

                    b.Navigation("PullRequest");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Backend.Models.Event", b =>
                {
                    b.HasOne("Backend.Models.Issue", "Issue")
                        .WithMany("Events")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Milestone", "Milestone")
                        .WithMany("Events")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.PullRequest", "PullRequest")
                        .WithMany("Events")
                        .HasForeignKey("PullRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Reaction", "Reaction")
                        .WithMany("Events")
                        .HasForeignKey("ReactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issue");

                    b.Navigation("Milestone");

                    b.Navigation("PullRequest");

                    b.Navigation("Reaction");
                });

            modelBuilder.Entity("Backend.Models.Issue", b =>
                {
                    b.HasOne("Backend.Models.Developer", null)
                        .WithMany("AssignedIssues")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Backend.Models.Milestone", "Milestone")
                        .WithMany("Issues")
                        .HasForeignKey("MilestoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Project", null)
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Milestone");
                });

            modelBuilder.Entity("Backend.Models.Milestone", b =>
                {
                    b.HasOne("Backend.Models.Project", "Project")
                        .WithMany("Milestones")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Backend.Models.PullRequest", b =>
                {
                    b.HasOne("Backend.Models.Project", null)
                        .WithMany("PullRequests")
                        .HasForeignKey("ProjectId");

                    b.HasOne("Backend.Models.Branch", "SourceBranch")
                        .WithMany()
                        .HasForeignKey("SourceBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Branch", "TargetBranch")
                        .WithMany()
                        .HasForeignKey("TargetBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SourceBranch");

                    b.Navigation("TargetBranch");
                });

            modelBuilder.Entity("Backend.Models.Reaction", b =>
                {
                    b.HasOne("Backend.Models.Developer", null)
                        .WithMany("Reactions")
                        .HasForeignKey("DeveloperId");

                    b.HasOne("Backend.Models.Issue", null)
                        .WithMany("Reactions")
                        .HasForeignKey("IssueId");

                    b.HasOne("Backend.Models.PullRequest", null)
                        .WithMany("Reactions")
                        .HasForeignKey("PullRequestId");
                });

            modelBuilder.Entity("DeveloperProject", b =>
                {
                    b.HasOne("Backend.Models.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Backend.Models.Project", null)
                        .WithMany()
                        .HasForeignKey("StarredProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Backend.Models.Developer", b =>
                {
                    b.Navigation("AssignedIssues");

                    b.Navigation("Comments");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Backend.Models.Issue", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Backend.Models.Milestone", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Issues");
                });

            modelBuilder.Entity("Backend.Models.Project", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Milestones");

                    b.Navigation("PullRequests");
                });

            modelBuilder.Entity("Backend.Models.PullRequest", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("Backend.Models.Reaction", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
