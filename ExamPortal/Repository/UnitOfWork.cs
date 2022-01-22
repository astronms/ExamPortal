using System;
using System.Collections.Generic;
using System.Linq;
using ExamPortal.Data;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Users;
using ExamPortal.IRepository;
using Task = System.Threading.Tasks.Task;

namespace ExamPortal.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Session> _sessions;
        private IGenericRepository<Exam> _exams;
        private IGenericRepository<Course> _courses;
        private IGenericRepository<User> _users;
        private IGenericRepository<CourseUser> _courseUser;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Session> Sessions => _sessions ??= new GenricRepository<Session>(_context);
        public IGenericRepository<Exam> Exams => _exams ??= new GenricRepository<Exam>(_context);
        public IGenericRepository<Course> Courses => _courses ??= new GenricRepository<Course>(_context);
        public IGenericRepository<User> Users => _users ??= new GenricRepository<User>(_context);
        public IGenericRepository<CourseUser> CourseUsers => _courseUser ??=new GenricRepository<CourseUser>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
