using Octovis.Location.Application.UseCases.Commands.CreateLocation;
using Octovis.Location.Domain.AggregateModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateRegion
{
    public class CreateRegionCommand : CreateLocationCommand
    {
        public AddressType AddressType { get; set; }
        public Guid AddressId { get; set; }
    }
}
