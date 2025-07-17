using Ardalis.GuardClauses;
using LMS.Application.Common.Interfaces;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using LMS.Domian.ValueObjects;
using MediatR;

namespace LMS.Application.Students.Commands.CreateStudentWithParentAndGuardian
{
    public class CreateStudentWithParentAndGuardianHandler : IRequestHandler<CreateStudentWithParentAndGuardianCommand, Guid>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateStudentWithParentAndGuardianHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateStudentWithParentAndGuardianCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request.Parent);

            var isExisitEmail = await _repo.ExistsByEmailAsync(request.Student.Email);

            if(isExisitEmail)
            throw new ArgumentException("this emial is already exist");



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
                string.Empty,
                true
            );

            var parent = new Parent(
                    request.Parent.FirstName,
                    request.Parent.LastName,
                    request.Parent.Occupation,
                    new PhoneNumber(request.Parent.PhoneNumber),
                    new Email(request.Parent.Email));

            student.AssignParent(parent);

            Guardian guardian;

            if (request.Parent.IsGuardianSameAsParent)
            {

                guardian = Guardian.CreateFromParent(parent);
            }

            else
            {
                Guard.Against.Null(request.Guardian);

                guardian = new Guardian(
                    request.Guardian.FullName,
                    request.Guardian.Relationship,
                    request.Guardian.ContactInfo);
            }

            student.AssignGuardian(guardian);

            await _repo.AddAsync(student);
            await _uow.CommitAsync(cancellationToken);
            student.FinalizeRegistration();
            return student.Id;
        }
    }

}
