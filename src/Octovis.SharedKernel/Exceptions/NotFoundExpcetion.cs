using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.SharedKernel.Exceptions
{
    public class NotFoundExpcetion : Exception
    {
        public NotFoundExpcetion(string message) : base(message)
        {
        }
        public NotFoundExpcetion(string message, Exception innerException) : base(message, innerException)
        {
        }
        public NotFoundExpcetion() : base("A application logic exception occurred.")
        {
        }

    }
}
