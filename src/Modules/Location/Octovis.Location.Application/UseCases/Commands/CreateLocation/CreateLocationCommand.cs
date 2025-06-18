using MediatR;
using Octovis.Location.Domain.AggregateModels.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation
{
    public class CreateLocationCommand:IRequest<bool>
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationType LocationType { get; set; } 

    }
}
