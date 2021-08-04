using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Infrastructure.Context
{
    public partial class VismyContext : IdentityDbContext<AspNetUser, IdentityRole, string>
    {
        public VismyContext()
        {
        }

        public VismyContext(DbContextOptions<VismyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostStatus> PostStatuses { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportStatus> ReportStatuses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserPost> UserPosts { get; set; }
        public virtual DbSet<UserPostStatus> UserPostStatuses { get; set; }
        public virtual DbSet<UserReportAuthor> UserReportAuthors { get; set; }
        public virtual DbSet<UserReportModerator> UserReportModerators { get; set; }
        public virtual DbSet<UserReportModeratorStatus> UserReportModeratorStatuses { get; set; }
        public virtual DbSet<UserUser> UserUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Vismy_tmp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() {Name = "User", NormalizedName = "USER"},
                new IdentityRole() {Name = "Moderator", NormalizedName = "MODERATOR"},
                new IdentityRole() {Name = "Administrator", NormalizedName = "ADMINISTRATOR"});

            modelBuilder.Entity<ReportStatus>().HasData(
                new ReportStatus() {Id = Guid.NewGuid().ToString(), Name = "Violence", Description = "Violence"},
                new ReportStatus() {Id = Guid.NewGuid().ToString(), Name = "Sexual content", Description = "Sexual content"},
                new ReportStatus() {Id = Guid.NewGuid().ToString(), Name = "Bullying", Description = "Bullying"},
                new ReportStatus() {Id = Guid.NewGuid().ToString(), Name = "Drugs", Description = "Drugs"});

            modelBuilder.Entity<PostStatus>().HasData(
                new PostStatus() {Id = Guid.NewGuid().ToString(), Name = "None", Description = "None"},
                new PostStatus() {Id = Guid.NewGuid().ToString(), Name = "Hidden", Description = "Hidden"},
                new PostStatus() {Id = Guid.NewGuid().ToString(), Name = "Frozen", Description = "Frozen"},
                new PostStatus() {Id = Guid.NewGuid().ToString(), Name = "Removed", Description = "Removed"});

            modelBuilder.Entity<UserPostStatus>().HasData(
                new UserPostStatus() {Id = Guid.NewGuid().ToString(), Name = "Viewed", Description = "View shows you viewed the post before."},
                new UserPostStatus() {Id = Guid.NewGuid().ToString(), Name = "Liked", Description = "Like shows you appreciate the post."});

            modelBuilder.Entity<UserReportModeratorStatus>().HasData(
                new UserReportModeratorStatus() {Id = Guid.NewGuid().ToString(), Name = "Approved", Description = "Approved"},
                new UserReportModeratorStatus() {Id = Guid.NewGuid().ToString(), Name = "Disapproved", Description = "Disapproved"});

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Surname).HasMaxLength(30);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.PostStatusId, "IX_Posts_Post_StatusId");

                entity.HasIndex(e => e.UserId, "IX_Posts_UserId");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.PostStatusId).HasColumnName("Post_StatusId");

                entity.HasOne(d => d.PostStatus)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostStatusId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PostStatus>(entity =>
            {
                entity.ToTable("Post_Status");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.TagId });

                entity.ToTable("Post_Tag");

                entity.HasIndex(e => e.TagId, "IX_Post_Tag_TagId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasIndex(e => e.PostId, "IX_Reports_PostId");

                entity.HasIndex(e => e.ReportStatusId, "IX_Reports_Report_StatusId");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.ReportStatusId).HasColumnName("Report_StatusId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ReportStatus)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportStatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReportStatus>(entity =>
            {
                entity.ToTable("Report_Status");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserPost>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PostId });

                entity.ToTable("User_Post");

                entity.HasIndex(e => e.PostId, "IX_User_Post_PostId");

                entity.HasIndex(e => e.UserPostStatusId, "IX_User_Post_User_Post_StatusId");

                entity.Property(e => e.UserPostStatusId).HasColumnName("User_Post_StatusId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.UserPostStatus)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserPostStatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserPostStatus>(entity =>
            {
                entity.ToTable("User_Post_Status");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserReportAuthor>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ReportId });

                entity.ToTable("User_Report_Author");

                entity.HasIndex(e => e.ReportId, "IX_User_Report_Author_ReportId");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserReportAuthors)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportAuthors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserReportModerator>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ReportId });

                entity.ToTable("User_Report_Moderator");

                entity.HasIndex(e => e.ReportId, "IX_User_Report_Moderator_ReportId");

                entity.HasIndex(e => e.UserReportModeratorStatusId, "IX_User_Report_Moderator_User_Report_Moderator_StatusId");

                entity.Property(e => e.UserReportModeratorStatusId).HasColumnName("User_Report_Moderator_StatusId");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.UserReportModerators)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportModerators)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.UserReportModeratorStatus)
                    .WithMany(p => p.UserReportModerators)
                    .HasForeignKey(d => d.UserReportModeratorStatusId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<UserReportModeratorStatus>(entity =>
            {
                entity.ToTable("User_Report_Moderator_Status");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserUser>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FollowerId });

                entity.ToTable("User_User");

                entity.HasIndex(e => e.FollowerId, "IX_User_User_FollowerId");

                entity.HasOne(d => d.Follower)
                    .WithMany(p => p.UserUserFollowers)
                    .HasForeignKey(d => d.FollowerId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
