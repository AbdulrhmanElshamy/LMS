using LMS.Application.Students.DTOs;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Application.Students.Queries.GetAllStudents
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentBasicInfoDto>>
    {
        private readonly IStudentRepository _repo;

        public GetAllStudentsHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<StudentBasicInfoDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var loweredName = request.filter?.Name?.ToLower();
            var year = request.filter?.Year;
            var gender = request.filter?.Gender;

            Expression<Func<Student, bool>> predicate = student =>
                (string.IsNullOrEmpty(loweredName) ||
                    EF.Functions.Like(student.FirstName.ToLower(), $"%{loweredName}%") ||
                    EF.Functions.Like(student.LastName.ToLower(), $"%{loweredName}%")) &&
                (!year.HasValue || student.EnrollmentYear == year) &&
                (gender == null || student.Gender == gender);

            var students = await _repo.GetAllAsync(predicate);

            return students.Select(student => new StudentBasicInfoDto
            {
                DateOfBirth = student.DateOfBirth,
                Email = student.Email.ToString(),
                EnrollmentYear = student.EnrollmentYear,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Language = student.Language,
                LastName = student.LastName,
                Mobile = student.Mobile.ToString(),
                Nationality = student.Nationality,
                Notes = student.Notes
            }).ToList();
        }
    }

}
