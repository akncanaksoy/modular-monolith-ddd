using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.Exceptions
{
    public class BusinessRuleException:Exception
    {
        public BusinessRuleException(string message) : base(message)
        {
        }
        public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public BusinessRuleException() : base("A business rule exception occurred.")
        {
        }

    }
}
