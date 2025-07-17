using LMS.Application.Common.Interfaces;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Commands.FinalizeStudentRegistration
{
    public class FinalizeStudentRegistrationHandler : IRequestHandler<FinalizeStudentRegistrationCommand, Unit>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public FinalizeStudentRegistrationHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(FinalizeStudentRegistrationCommand request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.StudentId) ?? throw new Exception("Student not found");

            student.FinalizeRegistration();
            await _uow.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
