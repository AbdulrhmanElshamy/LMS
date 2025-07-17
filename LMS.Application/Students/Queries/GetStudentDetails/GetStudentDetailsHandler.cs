
using LMS.Application.Students.DTOs;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Queries.GetStudentDetails
{
    public class GetStudentDetailsHandler : IRequestHandler<GetStudentDetailsQuery, StudentBasicInfoDto>
    {
        private readonly IStudentRepository _repo;

        public GetStudentDetailsHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<StudentBasicInfoDto> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Student not found");
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
