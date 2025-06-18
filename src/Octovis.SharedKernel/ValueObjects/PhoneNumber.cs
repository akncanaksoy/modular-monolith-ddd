using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.SharedKernel.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public string CountryCode { get; }
        public string Number { get; }

        public PhoneNumber(string countryCode, string number)
        {
            CountryCode = countryCode;
            Number = number;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return CountryCode;
            yield return Number;
        }

        public override string ToString() => $"+{CountryCode}{Number}";
    }

}
