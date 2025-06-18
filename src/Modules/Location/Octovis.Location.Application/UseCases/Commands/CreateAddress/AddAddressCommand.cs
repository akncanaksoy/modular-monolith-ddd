using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateAddress
{
    public class AddAddressCommand : IRequest<bool>
    {
        public Guid CountryId { get; set; }
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public string Longitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;

    }
}
