using LMS.Application.Students.DTOs;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Queries.GetStudentByEmail
{
    public class GetStudentByEmailHandler : IRequestHandler<GetStudentByEmailQuery, StudentDetailesDto>
    {
        private readonly IStudentRepository _repo;

        public GetStudentByEmailHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<StudentDetailesDto> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByEmailAsync(request.Email) ?? throw new KeyNotFoundException("Student not found");

            return new StudentDetailesDto
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

            };

        }
    }
}
