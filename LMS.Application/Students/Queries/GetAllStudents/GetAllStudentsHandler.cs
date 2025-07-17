using LMS.Application.Students.DTOs;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Application.Students.Queries.GetAllStudents
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<StudentDetailesDto>>
    {
        private readonly IStudentRepository _repo;

        public GetAllStudentsHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<StudentDetailesDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
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

            return students.Select(student => new StudentDetailesDto
            {
                Id = student.Id,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email.ToString(),
                EnrollmentYear = student.EnrollmentYear,
                FirstName = student.FirstName,
                Gender = student.Gender,
                Language = student.Language,
                LastName = student.LastName,
                Mobile = student.Mobile.ToString(),
                Nationality = student.Nationality,
                Notes = student.Notes,
                Parent = new ParentDetailesDto
                {
                    Id = student.Parent.Id,
                    Email = student.Parent.Email.ToString(),
                    FirstName = student.Parent.FirstName,
                    LastName = student.Parent.LastName,
                    Occupation = student.Parent.Occupation,
                    PhoneNumber = student.Parent.PhoneNumber.ToString()
                },
                Guardian = new GuardianDeatilesDto
                {
                    Id = student.Guardian.Id,
                    ContactInfo = student.Guardian.ContactInfo,
                    FullName = student.Guardian.FullName,
                    Relationship = student.Guardian.Relationship
                }

            }).ToList();
        }
    }

}
