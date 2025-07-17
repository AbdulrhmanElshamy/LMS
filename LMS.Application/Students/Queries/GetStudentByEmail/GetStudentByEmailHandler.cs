using LMS.Application.Students.DTOs;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Queries.GetStudentByEmail
{
    public class GetStudentByEmailHandler : IRequestHandler<GetStudentByEmailQuery, StudentBasicInfoDto>
    {
        private readonly IStudentRepository _repo;

        public GetStudentByEmailHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<StudentBasicInfoDto> Handle(GetStudentByEmailQuery request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByEmailAsync(request.Email) ?? throw new KeyNotFoundException("Student not found");
            return new StudentBasicInfoDto
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
            };
        }
    }
}
