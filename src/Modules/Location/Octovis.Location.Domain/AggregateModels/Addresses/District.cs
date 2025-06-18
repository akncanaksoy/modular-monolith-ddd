using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Addresses
{
    public class District : Entity
    {
        public string Name { get; private set; }
        public Guid CityId { get; private set; }


        internal District(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
