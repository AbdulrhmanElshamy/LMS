using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Queries.GetParentAndGuardianByStudentId
{
    public record GetParentAndGuardianByStudentIdQuery(Guid StudentId) : IRequest<ParentGuardianDetailes>;
}