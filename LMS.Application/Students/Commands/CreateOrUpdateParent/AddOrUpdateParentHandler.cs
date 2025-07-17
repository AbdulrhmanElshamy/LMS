using Ardalis.GuardClauses;
using LMS.Application.Common.Interfaces;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using LMS.Domian.ValueObjects;
using MediatR;

namespace LMS.Application.Students.Commands.CreateOrUpdateParent
{
    public class AddOrUpdateParentHandler : IRequestHandler<AddOrUpdateParentCommand,Unit>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public AddOrUpdateParentHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(AddOrUpdateParentCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.Null(request.Parent);
            Guard.Against.NullOrWhiteSpace(request.Parent.FirstName);
            Guard.Against.NullOrWhiteSpace(request.Parent.LastName);

            var student = await _repo.GetByIdAsync(request.StudentId) ?? throw new Exception("Student not found");

            var parent = new Parent (
                request.Parent.FirstName, 
                request.Parent.LastName,
                request.Parent.Occupation,
                new PhoneNumber(request.Parent.PhoneNumber),
                new Email(request.Parent.Email)
            );

            student.AssignParent(parent);

            if(request.Parent.IsGuardianSameAsParent)
            {
                Guardian guardian = Guardian.CreateFromParent(parent);
                
                student.AssignGuardian(guardian);
            }


            await _uow.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
