using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Commands.CreateStudentBasicInfo
{
    public record CreateStudentBasicInfoCommand(
StudentBasicInfoDto Student
  ) : IRequest<Guid>;
}
