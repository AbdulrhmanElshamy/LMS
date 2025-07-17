using LMS.Application.Students.Commands.CreateStudentWithParentAndGuardian;
using LMS.Application.Students.DTOs;
using MediatR;


namespace LMS.Application.Students.Commands.UpdateStudentWithRelations
{
    public record UpdateStudentWithRelationsCommand(Guid Id, StudentBasicInfoDto Student, ParentDto Parent, GuardianDto Guardian) : IRequest<Unit>;

}
