using LMS.Domian.Entities;
using System.Linq.Expressions;

namespace LMS.Domian.Interfaces
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);
        Task RemoveAsync(Student student);
        Task<Student?> GetByIdAsync(Guid id);
        Task<bool> ExistsByEmailAsync(string email);
        Task<Student?> GetByEmailAsync(string email);

        Task<IQueryable<Student>> GetAllAsync(Expression<Func<Student, bool>> predicate);
    }
}
