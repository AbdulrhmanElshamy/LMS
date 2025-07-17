using LMS.Application.Students.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMS.Application.Students.Commands.CreateStudentWithParentAndGuardian
{
    public record CreateStudentWithParentAndGuardianCommand(StudentBasicInfoDto Student, ParentDto Parent, GuardianDto Guardian) : IRequest<Guid>;

}
