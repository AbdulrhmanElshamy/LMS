using FluentValidation;

namespace LMS.Application.Students.Commands.CreateOrUpdateParent
{
    public class AddOrUpdateParentCommandValidator : AbstractValidator<AddOrUpdateParentCommand>
    {
        public AddOrUpdateParentCommandValidator()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("StudentId is required");
            RuleFor(x => x.Parent).NotNull();
            RuleFor(x => x.Parent.FirstName).NotEmpty().WithMessage("Firstname is required");
            RuleFor(x => x.Parent.LastName).NotEmpty().WithMessage("Lastname is required");
        }
    }

}
