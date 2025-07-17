
using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Queries.GetStudentDetails
{
    public record GetStudentDetailsQuery(Guid Id) : IRequest<StudentDetailesDto>;
}
