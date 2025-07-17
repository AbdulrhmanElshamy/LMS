using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Students.Commands.FinalizeStudentRegistration
{
    public record FinalizeStudentRegistrationCommand(Guid StudentId) : IRequest<Unit>;
}
