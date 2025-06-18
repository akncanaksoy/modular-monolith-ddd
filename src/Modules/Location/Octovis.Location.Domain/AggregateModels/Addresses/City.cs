using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Addresses
{
  
    public class City : Entity
    {
        public string Name { get; private set; }
        public Guid CountryId { get; private set; }


        private readonly List<District> _districts = new();
        public IReadOnlyCollection<District> Districts => _districts;


        internal City(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public District AddDistrict(Guid districtId, string name)
        {
            if (_districts.Any(d => d.Id == districtId))
                throw new BusinessRuleException("District already exists.");

            var district = new District(districtId, name);
            _districts.Add(district);
            return district;
        }
    }

}
