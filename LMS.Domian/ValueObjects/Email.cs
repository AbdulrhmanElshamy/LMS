using LMS.Domian.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
