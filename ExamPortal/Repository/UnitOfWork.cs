using System;
using System.Collections.Generic;
using System.Linq;
using ExamPortal.Data;
using ExamPortal.Data.ActivetedExams;
using ExamPortal.Data.Answers;
using ExamPortal.Data.ExamData;
using ExamPortal.Data.Result;
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
        private IGenericRepository<ActivatedExam> _activatedExams;
        private IGenericRepository<ExamAnswers> _examAnswers;
        private IGenericRepository<SessionResult> _sessionsResults;
        private IGenericRepository<ExamResult> _examResults;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Session> Sessions => _sessions ??= new GenericRepository<Session>(_context);
        public IGenericRepository<Exam> Exams => _exams ??= new GenericRepository<Exam>(_context);
        public IGenericRepository<Course> Courses => _courses ??= new GenericRepository<Course>(_context);
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<CourseUser> CourseUsers => _courseUser ??=new GenericRepository<CourseUser>(_context);
        public IGenericRepository<ActivatedExam> ActivatedExams => _activatedExams ??= new GenericRepository<ActivatedExam>(_context);
        public IGenericRepository<ExamAnswers> ExamAnswers => _examAnswers ??= new GenericRepository<ExamAnswers>(_context);
        public IGenericRepository<SessionResult> SessionResults => _sessionsResults ??= new GenericRepository<SessionResult>(_context);
        public IGenericRepository<ExamResult> ExamResults => _examResults ??= new GenericRepository<ExamResult>(_context);


        public async Task Save()
        {
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
