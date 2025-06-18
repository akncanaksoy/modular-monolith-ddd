using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public class Room : Entity
    {
        private Room() { }

        public Room(Guid id)
        {
            Id = id;
        }
    }
}
