using System.Linq;
using ExamPortal.Configuration.Entities;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
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
            builder.Entity<CourseUser>().HasOne(x => x.Course).WithMany(x => x.CourseUsers)
                .HasForeignKey(x => x.CourseId);
            builder.Entity<CourseUser>().HasOne(x => x.User).WithMany(x => x.CourseUsers)
                .HasForeignKey(x => x.UserId);
            builder.Entity<ActivatedExam>().HasOne(x => x.Exam).WithMany(x => x.ActivatedExams)
                .HasForeignKey(x => x.ExamId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ActivatedExam>().HasOne(x => x.User).WithMany(x => x.ActivatedExams)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<ActivatedExam>().HasOne(x => x.ExamAnswers).WithOne(x => x.ActivatedExams).OnDelete(DeleteBehavior.NoAction);
            builder.Entity<AnswersValue>().HasOne(x => x.Answers).WithMany(x => x.AnswersValue)
                .HasForeignKey(x => x.AnswersValueId).OnDelete(DeleteBehavior.NoAction);
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }

        public DbSet<ActivatedExam> ActivatedExams { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exam> Exams { get; set; }

        public DbSet<SessionAnswers> SessionAnswers { get; set; }
        public DbSet<ExamAnswers> ExamAnswers { get; set; }
    }
}
