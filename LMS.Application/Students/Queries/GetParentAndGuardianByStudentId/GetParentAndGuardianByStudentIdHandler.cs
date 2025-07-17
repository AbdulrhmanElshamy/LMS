using LMS.Application.Students.DTOs;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Queries.GetParentAndGuardianByStudentId
{
    public class GetParentAndGuardianByStudentIdHandler : IRequestHandler<GetParentAndGuardianByStudentIdQuery, ParentGuardianDetailes>
    {
        private readonly IStudentRepository _repo;

        public GetParentAndGuardianByStudentIdHandler(IStudentRepository repo)
        {
            _repo = repo;
        }

        public async Task<ParentGuardianDetailes> Handle(GetParentAndGuardianByStudentIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.StudentId) ?? throw new KeyNotFoundException("Student not found");
            return new ParentGuardianDetailes
            {
                Parent = new ParentDetailesDto
                {
                    Id = student.Id,
                    Email = student.Parent?.Email!.ToString() ?? "",
                    FirstName = student.Parent?.FirstName ?? "",
                    LastName = student.Parent?.LastName ?? "",
                    Occupation = student.Parent?.Occupation ?? "",
                    PhoneNumber = student.Parent?.PhoneNumber!.ToString() ?? ""
                },
                Guardian = new GuardianDeatilesDto
                {
                    ContactInfo = student.Guardian?.ContactInfo ?? "",
                    FullName = student.Guardian?.FullName ?? "",
                    Relationship = student.Guardian?.Relationship ?? ""
                }
            };
        }
    }
}