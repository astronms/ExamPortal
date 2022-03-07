using System.Linq;
using ExamPortal.Configuration.Entities;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Result;
using ExamPortal.Data.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;


namespace ExamPortal.Data
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            SeedSuperAdmin(builder);

            builder.Entity<CourseUser>().HasOne(x => x.Course).WithMany(x => x.CourseUsers)
                .HasForeignKey(x => x.CourseId);
            builder.Entity<CourseUser>().HasOne(x => x.User).WithMany(x => x.CourseUsers)
                .HasForeignKey(x => x.UserId);
            builder.Entity<ActivatedExam>().HasOne(x => x.Exam).WithMany(x => x.ActivatedExams)
                .HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<ActivatedExam>().HasOne(x => x.User).WithMany(x => x.ActivatedExams)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.SetNull);
            builder.Entity<ActivatedExam>().HasOne(x => x.ExamAnswers).WithOne(x => x.ActivatedExams).OnDelete(DeleteBehavior.SetNull);
        }
        private void SeedSuperAdmin(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "superadmin@gmail.com",
                Email = "superadmin@gmail.com",
                LockoutEnabled = false,
                FirstName = "Super",
                LastName = "Admin",
                NormalizedUserName = "SUPERADMIN@GMAIL.COM",
                NormalizedEmail = "SUPERADMIN@GMAIL.COM"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, "zaq1@WSX!");

            builder.Entity<User>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "a91f4dbc-8020-4052-b7c1-8cb3d46de4fd", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
            );
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        public DbSet<ActivatedExam> ActivatedExams { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamAnswers> ExamAnswers { get; set; }

        public DbSet<SessionResult> SessionsResult { get; set; }
    }
}
