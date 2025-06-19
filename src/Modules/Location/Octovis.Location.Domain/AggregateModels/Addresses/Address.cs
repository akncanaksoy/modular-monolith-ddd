using Octovis.SharedKernel.Domain;


namespace Octovis.Location.Domain.AggregateModels.Addresses
{
    public class Address : Entity, IAggregateRoot
    {
        public Guid CountryId { get; private set; }
        public Guid CityId { get; private set; }
        public Guid DistrictId { get; private set; }
        public string Longitude { get; private set; } = string.Empty;
        public string Latitude { get; private set; } = string.Empty;

        public Country Country { get; private set; }
        public City City { get; private set; }
        public District District { get; private set; }

        private Address() { } // EF için

        private Address(Guid countryId, Guid cityId, Guid districtId , string latitude, string longitude)
        {
            Id = Guid.NewGuid();
            CountryId = countryId;
            CityId = cityId;
            DistrictId = districtId;
            Latitude = latitude;
            Longitude = longitude;
        }

        public static Address Create(Guid countryId, Guid cityId, Guid districtId, string latitude, string longitude)
        {
            if (countryId == Guid.Empty)
                throw new ArgumentException("Country ID cannot be empty.", nameof(countryId));
            if (cityId == Guid.Empty)
                throw new ArgumentException("City ID cannot be empty.", nameof(cityId));
            if (districtId == Guid.Empty)
                throw new ArgumentException("District ID cannot be empty.", nameof(districtId));
            if (string.IsNullOrWhiteSpace(latitude))
                throw new ArgumentException("Latitude cannot be empty.", nameof(latitude));
            if (string.IsNullOrWhiteSpace(longitude))
                throw new ArgumentException("Longitude cannot be empty.", nameof(longitude));

            var address =new Address(countryId, cityId, districtId, latitude, longitude);

            return address;

        }

        public class User
        {
            public string Name { get; private set; }
            public string Password { get; private set; }


           
        }

    }

}
