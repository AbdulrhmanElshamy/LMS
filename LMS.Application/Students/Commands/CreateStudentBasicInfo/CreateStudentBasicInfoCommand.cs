using LMS.Application.Students.DTOs;
using LMS.Domian.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LMS.Application.Students.Commands.CreateStudentBasicInfo
{
    public record CreateStudentBasicInfoCommand(
StudentBasicInfoDto Student
  ) : IRequest<Guid>;
}
