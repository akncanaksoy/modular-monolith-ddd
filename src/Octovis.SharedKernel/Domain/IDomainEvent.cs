using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.SharedKernel.Domain
{
    public interface IDomainEvent
    {
        DateTime OccurredOn { get; }
    }

    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; protected set; }

        protected DomainEvent()
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
