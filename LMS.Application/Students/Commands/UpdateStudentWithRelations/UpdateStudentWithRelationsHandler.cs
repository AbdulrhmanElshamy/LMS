using LMS.Application.Common.Interfaces;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using LMS.Domian.ValueObjects;
using MediatR;


namespace LMS.Application.Students.Commands.UpdateStudentWithRelations
{
    public class UpdateStudentWithRelationsHandler : IRequestHandler<UpdateStudentWithRelationsCommand, Unit>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateStudentWithRelationsHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateStudentWithRelationsCommand request, CancellationToken cancellationToken)
        {
            var studentByEmail = await _repo.GetByEmailAsync(request.Student.Email);

            var student = await _repo.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Student not found");


            if (studentByEmail is not null && studentByEmail != student)
                throw new ArgumentException("this emial is already exist");

            student.UpdateBasicInfo(request.Student.FirstName,
                request.Student.LastName,
                request.Student.DateOfBirth,
                request.Student.Gender,
                request.Student.Nationality,
                new Email(request.Student.Email),
                new PhoneNumber(request.Student.Mobile),
                request.Student.EnrollmentYear,
                request.Student.LastName,
                request.Student.Notes);


            student.AssignParent(new Parent
                (request.Parent.FirstName,
                request.Parent.LastName,
                request.Parent.Occupation,
                new PhoneNumber(request.Parent.PhoneNumber),
                new Email(request.Parent.Email)));


            student.AssignGuardian(new Guardian
                (request.Guardian.FullName,
                request.Guardian.Relationship,
                request.Guardian.ContactInfo));

            await _uow.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
