using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vismy.Core.Models.Implementations;
using Vismy.Core.Models.Joins;
using Vismy.Core.Models.Statuses;

#nullable disable

namespace Vismy.Infrastructure.Context
{
    public partial class VismyContext : IdentityDbContext<AspNetUser, IdentityRole<int>, int>
    {
        public VismyContext()
        {
        }

        public VismyContext(DbContextOptions<VismyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
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
        public virtual DbSet<UserStatus> UserStatuses { get; set; }
        public virtual DbSet<UserUser> UserUsers { get; set; }
        public virtual DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Vismy;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.UserStatusId, "IX_AspNetUsers_User_StatusId");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Surname).HasMaxLength(30);

                entity.Property(e => e.UserName).HasMaxLength(20);

                entity.Property(e => e.UserStatusId).HasColumnName("User_StatusId");

                entity.HasOne(d => d.UserStatus)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.UserStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId);
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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasIndex(e => e.PostId, "IX_Reports_PostId");

                entity.HasIndex(e => e.ReportStatusId, "IX_Reports_Report_StatusId");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.ReportStatusId).HasColumnName("Report_StatusId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.PostId);

                entity.HasOne(d => d.ReportStatus)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.ReportStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UserPostStatus)
                    .WithMany(p => p.UserPosts)
                    .HasForeignKey(d => d.UserPostStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportAuthors)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserReportModerators)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UserReportModeratorStatus)
                    .WithMany(p => p.UserReportModerators)
                    .HasForeignKey(d => d.UserReportModeratorStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<UserReportModeratorStatus>(entity =>
            {
                entity.ToTable("User_Report_Moderator_Status");

                entity.Property(e => e.Description).HasMaxLength(160);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.ToTable("User_Status");

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
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.HasIndex(e => e.PostId, "IX_Video_PostId")
                    .IsUnique();

                entity.Property(e => e.Path).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Post)
                    .WithOne(p => p.Video)
                    .HasForeignKey<Video>(d => d.PostId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
