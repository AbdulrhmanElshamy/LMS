using LMS.Domian.Common;

namespace LMS.Domian.Entities
{
    public class Guardian : Entity
    {
        public Guid StudentId { get; private set; }

        public string FullName { get; private set; }
        public string? Relationship { get; private set; }
        public string? ContactInfo { get; private set; }

        private Guardian() { }

        public Guardian(string fullName, string? relationship, string? contactInfo)
        {
            FullName = fullName;
            Relationship = relationship;
            ContactInfo = contactInfo;
        }


        internal void AssignStudent(Student student)
        {
            StudentId = student.Id;
        }

        public static Guardian CreateFromParent(Parent parent)
        {
            return new Guardian(
                fullName:$"{parent.FirstName} {parent.LastName}",
                relationship: "Parent",
                contactInfo: parent.PhoneNumber?.ToString() ?? ""
            );
        }
    }
}
