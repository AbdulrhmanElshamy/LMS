using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {

        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<Student?> GetByIdAsync(Guid id)
        {
            return await _context.Students
                .Include(s => s.Parent)
                .Include(s => s.Guardian)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Students.AnyAsync(s => s.Email.Value == email);
        }

        public async Task<Student?> GetByEmailAsync(string email)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email.Value == email);
        }


        public async Task<IQueryable<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate)
        {
            return _context.Students.Where(predicate).AsNoTracking();
        }

        public async Task RemoveAsync(Student student)
        {
            _context.Students.Remove(student);  
        }
    }
}
