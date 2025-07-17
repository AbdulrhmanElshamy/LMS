using MediatR;

namespace LMS.Application.Students.Commands.DeleteStudent
{
    public record DeleteStudentCommand(Guid Id) : IRequest<Unit>;

}
