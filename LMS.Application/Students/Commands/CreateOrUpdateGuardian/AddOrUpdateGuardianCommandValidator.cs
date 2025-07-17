using FluentValidation;

namespace LMS.Application.Students.Commands.CreateOrUpdateGuardian
{
    public class AddOrUpdateGuardianCommandValidator : AbstractValidator<AddOrUpdateGuardianCommand>
    {
        public AddOrUpdateGuardianCommandValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("StudentId is required");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Fullname is requeired");
        }
    }

}
