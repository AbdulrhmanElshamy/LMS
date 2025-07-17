using LMS.Application.Students.DTOs;
using LMS.Domian.Entities;
using LMS.Domian.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Students.Queries.GetAllStudents
{
    public record GetAllStudentsQuery(Filter filter) : IRequest<List<StudentBasicInfoDto>>;

}
