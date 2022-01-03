using System;
using System.Collections.Generic;
using System.Linq;
using ExamPortal.Data;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using Task = System.Threading.Tasks.Task;

namespace ExamPortal.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Session> Sessions { get; }

        IGenericRepository<Exam> Exams { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<User> Users { get; }

        Task Save();
    }
}
