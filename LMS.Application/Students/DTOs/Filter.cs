using LMS.Domian.Enums;

namespace LMS.Application.Students.DTOs
{
    public record Filter(string? Name, int? Year, Gender? Gender);
}
