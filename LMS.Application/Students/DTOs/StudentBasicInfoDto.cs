using LMS.Domian.Enums;

namespace LMS.Application.Students.DTOs
{
    public class StudentBasicInfoDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Nationality { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public int EnrollmentYear { get; set; }
        public string? Notes { get; set; }
        public string Language { get; set; } = default!;
    }
}
