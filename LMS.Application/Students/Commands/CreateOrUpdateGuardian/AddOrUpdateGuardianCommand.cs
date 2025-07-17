using MediatR;
namespace LMS.Application.Students.Commands.CreateOrUpdateGuardian
{
    public record AddOrUpdateGuardianCommand(
      Guid StudentId,
      string FullName,
      string Relationship,
      string ContactInfo
  ) : IRequest<Unit>;

}
