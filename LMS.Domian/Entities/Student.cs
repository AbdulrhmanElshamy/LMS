using LMS.Domian.Common;
using LMS.Domian.Enums;
using LMS.Domian.ValueObjects;

namespace LMS.Domian.Entities
{
    public class Student : AggregateRoot
    {

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Gender Gender { get; private set; }
        public string Nationality { get; private set; }
        public Email Email { get; private set; }
        public PhoneNumber Mobile { get; private set; }
        public int EnrollmentYear { get; private set; }
        public string Language { get; private set; }
        public string Notes { get; private set; }
        public bool IsDraft { get; private set; }

        public Parent? Parent { get; private set; }
        public Guardian? Guardian { get; private set; }

        private Student() { }

        public Student(
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            Gender gender,
            string nationality,
            Email email,
            PhoneNumber mobile,
            int enrollmentYear,
            string language,
            string notes,
            bool isDraft)
        {

            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationality = nationality;
            Email = email;
            Mobile = mobile;
            EnrollmentYear = enrollmentYear;
            Language = language;
            Notes = notes;
            IsDraft = isDraft;
        }

        public void UpdateBasicInfo(string firstName,
            string lastName,
            DateTime dateOfBirth,
            Gender gender,
            string nationality,
            Email email,
            PhoneNumber mobile,
            int enrollmentYear,
            string language,
            string notes)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Nationality = nationality;
            Email = email;
            Mobile = mobile;
            EnrollmentYear = enrollmentYear;
            Language = language;
            Notes = notes;
        }

        public void AssignParent(Parent parent)
        {
            parent = parent ?? throw new ArgumentNullException(nameof(parent));
            parent.AssignStudent(this);
            Parent = parent;
        }

        public void AssignGuardian(Guardian guardian)
        {
            guardian = guardian ?? throw new ArgumentNullException(nameof(guardian));
            guardian.AssignStudent(this);
            Guardian = guardian;
        }

        public void FinalizeRegistration()
        {
            if (Parent is null) throw new InvalidOperationException("Parent is required");
            if (Guardian is null) throw new InvalidOperationException("Guardian is required");
            IsDraft = false;
        }
    }
}
