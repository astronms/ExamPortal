using ExamPortal.Data.ExamData;
using ExamPortal.Data.ExamToSendModel;
using ExamPortal.Data.Users;
using Microsoft.EntityFrameworkCore;

namespace ExamPortal.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentInfo> StudentsInfos { get; set; }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Value> Values { get; set; }

        public DbSet<SessionToCheck> SessionsToCheck { get; set; }
        public DbSet<ExamToCheck> ExamsToCheck { get; set; }
        public DbSet<TaskToCheck> TasksToCheck { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ValueToCheck> ValuesToCheck { get; set; }

    }
}
