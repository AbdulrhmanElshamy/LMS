using Ardalis.GuardClauses;
using LMS.Application.Common.Interfaces;
using LMS.Domian.Entities;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Commands.CreateOrUpdateGuardian
{
    public class AddOrUpdateGuardianHandler : IRequestHandler<AddOrUpdateGuardianCommand,Unit>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public AddOrUpdateGuardianHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(AddOrUpdateGuardianCommand request, CancellationToken cancellationToken)
        {
            Guard.Against.NullOrWhiteSpace(request.FullName);


            var student = await _repo.GetByIdAsync(request.StudentId) ?? throw new Exception("Student not found");

            var guardian = new Guardian (
                request.FullName,
                request.Relationship,
                request.ContactInfo
            );

            student.AssignGuardian(guardian);
            await _uow.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
