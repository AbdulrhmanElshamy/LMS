using FluentValidation;


namespace LMS.Application.Students.Commands.UpdateStudentWithRelations
{
    public class UpdateStudentWithRelationsValidator : AbstractValidator<UpdateStudentWithRelationsCommand>
    {
        public UpdateStudentWithRelationsValidator()
        {
            RuleFor(x => x.Student).NotNull();
            RuleFor(x => x.Parent).NotNull();
            RuleFor(x => x.Guardian)
            .NotNull()
            .When(x => !x.Parent.IsGuardianSameAsParent);

            RuleFor(x => x.Student.FirstName).NotEmpty().WithMessage("Firstname is required");

            RuleFor(x => x.Student.LastName).NotEmpty().WithMessage("Lastname is required");

            RuleFor(x => x.Student.DateOfBirth).NotEmpty().WithMessage("DateOfBirth is required");

            RuleFor(x => x.Student.Gender).IsInEnum();

            RuleFor(x => x.Student.Nationality).NotEmpty().WithMessage("Nationality is not valid");

            RuleFor(x => x.Student.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");

            RuleFor(x => x.Student.Mobile).NotEmpty().WithMessage("Mobile is not valid");

            RuleFor(x => x.Student.EnrollmentYear).GreaterThan(2000).LessThan(2025);

            RuleFor(x => x.Student.Language).NotEmpty().WithMessage("Language is not valid");


            RuleFor(x => x.Parent.Email)
              .NotEmpty().WithMessage("Parent email is required")
              .EmailAddress().WithMessage("Parent email is not valid");

            RuleFor(x => x.Parent.PhoneNumber)
  .NotEmpty().WithMessage("Parent phoneNumber is required");


            RuleFor(x => x.Parent.FirstName)
  .NotEmpty().WithMessage("Parent FirstName is required");

            RuleFor(x => x.Parent.LastName)
.NotEmpty().WithMessage("Parent LastName is required");

            RuleFor(x => x.Guardian.FullName)
                .NotEmpty()
                .When(x => x.Guardian != null)
                .WithMessage("Guardian FullName is required");
        }
    }

}
