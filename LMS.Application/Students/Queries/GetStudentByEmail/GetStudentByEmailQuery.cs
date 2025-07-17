using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Queries.GetStudentByEmail
{
    public record GetStudentByEmailQuery(string Email) : IRequest<StudentDetailesDto>;
}
