namespace LMS.Application.Students.DTOs
{
    public class ParentDto
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Occupation { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public bool IsGuardianSameAsParent { get; set; }
    }
}
