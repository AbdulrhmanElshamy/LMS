using Ardalis.GuardClauses;
using LMS.Application.Common.Interfaces;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using LMS.Domian.ValueObjects;
using MediatR;

namespace LMS.Application.Students.Commands.CreateStudentBasicInfo
{
    public partial class CreateStudentBasicInfoHandler : IRequestHandler<CreateStudentBasicInfoCommand, Guid>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateStudentBasicInfoHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateStudentBasicInfoCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request.Student, nameof(request.Student));

            var student = new Student(
                request.Student.FirstName, 
                request.Student.LastName,
                request.Student.DateOfBirth,
                request.Student.Gender,
                request.Student.Nationality,
                new Email(request.Student.Email),
                new PhoneNumber(request.Student.Mobile),
                request.Student.EnrollmentYear,
                request.Student.Language,
                request.Student.Notes,
                true
            );

            await _repo.AddAsync(student);
            await _uow.CommitAsync(cancellationToken);
            return student.Id;
        }

    }
}
