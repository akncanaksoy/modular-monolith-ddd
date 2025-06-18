using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations
{
    
    public class Area : Entity
    {
        private Area() { }

        public Area(Guid id)
        {
            Id = id;
        }
    }
}
