using LMS.Application.Students.Commands.CreateStudentBasicInfo;
using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Commands.CreateStudentWithParentAndGuardian
{
    public record CreateStudentWithParentAndGuardianCommand(StudentBasicInfoDto Student, ParentDto Parent, GuardianDto Guardian) : IRequest<Guid>;

}
