using MediatR;

namespace LMS.Application.Students.Commands.FinalizeStudentRegistration
{
    public record FinalizeStudentRegistrationCommand(Guid StudentId) : IRequest<Unit>;
}
