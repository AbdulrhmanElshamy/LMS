using LMS.Application.Common.Interfaces;
using LMS.Domian.Interfaces;
using MediatR;

namespace LMS.Application.Students.Commands.DeleteStudent
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand,Unit>
    {
        private readonly IStudentRepository _repo;
        private readonly IUnitOfWork _uow;

        public DeleteStudentHandler(IStudentRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _repo.GetByIdAsync(request.Id) ?? throw new KeyNotFoundException("Student not found");
            await _repo.RemoveAsync(student);
            await _uow.CommitAsync(cancellationToken);
            return Unit.Value;
        }
    }

}
