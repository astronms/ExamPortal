using ExamPortal.Configuration.Entities;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.ExamToSendModel;
using ExamPortal.Data.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
        }


        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseUser> CourseUsers { get; set; }
        public DbSet<StudentInfo> StudentsInfos { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamTask> Tasks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Value> Values { get; set; }

        public DbSet<SessionToCheck> SessionsToCheck { get; set; }
        public DbSet<ExamToCheck> ExamsToCheck { get; set; }
        public DbSet<TaskToCheck> TasksToCheck { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ValueToCheck> ValuesToCheck { get; set; }

    }
}
