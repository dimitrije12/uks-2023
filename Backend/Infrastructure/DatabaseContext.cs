using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Milestone> Milestones { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<PullRequest> PullRequests { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<CreateEvent> CreateEvents { get; set; }
        public DbSet<UpdateEvent> UpdateEvents { get; set; }
        public DbSet<DeleteEvent> DeleteEvents { get; set; }
        public DbSet<OpenEvent> OpenEvents { get; set; }
        public DbSet<CloseEvent> CloseEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .HasIndex(d => d.Username)
                .IsUnique();
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Milestones)
                .WithOne(m => m.Project)
                .HasForeignKey(m => m.ProjectId);

            modelBuilder.Entity<Milestone>()
                .HasMany(m => m.Issues)
                .WithOne(i => i.Milestone)
                .HasForeignKey(i => i.MilestoneId);

            modelBuilder.Entity<Milestone>()
                .HasMany(m => m.Events)
                .WithOne(e => e.Milestone)
                .HasForeignKey(e => e.MilestoneId);

            modelBuilder.Entity<Issue>()
                .HasMany(i => i.Comments)
                .WithOne(c => c.Issue)
                .HasForeignKey(c => c.IssueId);

            modelBuilder.Entity<Issue>()
                .HasMany(i => i.Events)
                .WithOne(e => e.Issue)
                .HasForeignKey(e => e.IssueId);

            modelBuilder.Entity<PullRequest>()
                .HasMany(pr => pr.Comments)
                .WithOne(c => c.PullRequest)
                .HasForeignKey(c => c.PullRequestId);

            modelBuilder.Entity<PullRequest>()
                .HasMany(pr => pr.Events)
                .WithOne(e => e.PullRequest)
                .HasForeignKey(e => e.PullRequestId);

            modelBuilder.Entity<PullRequest>()
                .HasOne(pr => pr.SourceBranch)
                .WithMany()
                .HasForeignKey(pr => pr.SourceBranchId);

            modelBuilder.Entity<PullRequest>()
                .HasOne(pr => pr.TargetBranch)
                .WithMany()
                .HasForeignKey(pr => pr.TargetBranchId);

            modelBuilder.Entity<Developer>()
                .HasMany(d => d.Comments)
                .WithOne(c => c.Developer)
                .HasForeignKey(c => c.DeveloperId);

            modelBuilder.Entity<Reaction>()
                .HasMany(r => r.Comments)
                .WithOne(c => c.Reaction)
                .HasForeignKey(c => c.ReactionId);

            modelBuilder.Entity<Reaction>()
                .HasMany(r => r.Events)
                .WithOne(e => e.Reaction)
                .HasForeignKey(e => e.ReactionId);
        }
    }
}
