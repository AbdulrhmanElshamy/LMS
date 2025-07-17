using FluentValidation;

namespace LMS.Application.Students.Commands.CreateStudentBasicInfo
{
    public partial class CreateStudentBasicInfoHandler
    {
        public class CreateStudentBasicInfoCommandValidator : AbstractValidator<CreateStudentBasicInfoCommand>
        {
            public CreateStudentBasicInfoCommandValidator()
            {
                RuleFor(x => x.Student).NotNull();

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
            }
        }

    }
}
