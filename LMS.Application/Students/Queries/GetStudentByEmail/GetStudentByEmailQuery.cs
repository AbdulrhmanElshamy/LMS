using LMS.Application.Students.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Students.Queries.GetStudentByEmail
{
    public record GetStudentByEmailQuery(string Email) : IRequest<StudentBasicInfoDto>;
}
