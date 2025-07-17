using LMS.Domian.Common;
using LMS.Domian.ValueObjects;
using System;

namespace LMS.Domian.Entities
{
    public class Parent : Entity
    {
        public Guid StudentId { get; private set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Occupation { get; private set; }
        public PhoneNumber? PhoneNumber { get; private set; }
        public Email? Email { get; private set; }

        private Parent() { }

        public Parent(string firstName, string lastName, string? occupation, PhoneNumber? phoneNumber, Email? email)
        {
            FirstName = firstName;
            LastName = lastName;
            Occupation = occupation;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        internal void AssignStudent(Student student)
        {
            StudentId = student.Id;
        }
    }
}
