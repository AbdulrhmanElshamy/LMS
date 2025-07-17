using LMS.Domian.Common;

namespace LMS.Domian.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string Value { get; private set; }

        private PhoneNumber() { }

        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 11)
                throw new ArgumentException("Invalid phone number");

            Value = value;
        }

        public override string ToString() => Value;

        protected override IEnumerable<object> GetObjectValues()
        {
            return new List<object>
            {
                Value
            };
        }
    }
}
