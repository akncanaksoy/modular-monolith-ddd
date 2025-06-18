using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;


namespace Octovis.Location.Domain.AggregateModels.Addresses
{


    public class Country : Entity // Aggreagate Root olma potansiyeline sahip bir entity
    {

        public string Name { get; private set; }

        private readonly List<City> _cities = new();
        public IReadOnlyCollection<City> Cities => _cities;


        internal Country(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public City AddCity(Guid cityId, string name)
        {
            if (_cities.Any(d => d.Id == cityId))
                throw new BusinessRuleException("City already exists.");

            var city = new City(cityId, name);
            _cities.Add(city);
            return city;
        }




    }

}
