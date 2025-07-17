using LMS.Application.Students.DTOs;
using MediatR;

namespace LMS.Application.Students.Commands.CreateOrUpdateParent
{
    public record AddOrUpdateParentCommand(
    Guid StudentId,
    ParentDto Parent
  ) : IRequest<Unit>;

}
