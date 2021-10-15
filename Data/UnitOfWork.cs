using Core;
using Core.Interfaces.Repositories;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _context;
        public DbContext DbContext { get; }
        public IStudentRepository StudentRepository { get; set; }
        public ITeacherRepository TeacherRepository { get; set; }

        public UnitOfWork(DbContext context) //TODO: add DI
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);
            TeacherRepository = new TeacherRepository(_context);
        }
        
        public void Save()
        {
            _context.SaveChanges();
        }

        public void SetContext(DbContext context)
        {
            _context = context;
        }
        
        public void Dispose()
        {    
            _context.Dispose();
        }
    }
}