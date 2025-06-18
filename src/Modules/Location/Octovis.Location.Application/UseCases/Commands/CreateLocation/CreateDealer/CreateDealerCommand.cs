using Octovis.Location.Application.UseCases.Commands.CreateLocation;
using Octovis.Location.Domain.AggregateModels.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateDealer
{
    public class CreateDealerCommand : CreateLocationCommand
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressType AddressType { get; set; }
        public Guid AddressId { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
