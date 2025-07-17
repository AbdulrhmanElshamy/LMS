using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Queries.GetAllStudents
{
    public record GetAllStudentsQuery(Filter filter) : IRequest<List<StudentDetailesDto>>;

}
