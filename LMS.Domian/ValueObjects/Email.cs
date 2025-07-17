using LMS.Domian.Common;

namespace LMS.Domian.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; }

        private Email() { }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email format");

            Value = value;
        }

        public override string ToString() => Value;

        protected override IEnumerable<object> GetObjectValues()
        {
            return new List<object>()
            {
                Value
            };
        }
    }
}
