using Microsoft.EntityFrameworkCore;
using System;
using Core.Interfaces.Repositories;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; set; }
        
        ITeacherRepository TeacherRepository { get; set; }

        void Save();
        
        void SetContext(DbContext context);

        DbContext DbContext { get; }
    }
}