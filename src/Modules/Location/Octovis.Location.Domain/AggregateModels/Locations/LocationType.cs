using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Domain.AggregateModels.Locations
{
    public enum LocationType
    {
        Dealer = 1,
        Company = 2,
        Region = 3,
        Area = 4,
        Room = 5
    }

    public static class LocationTypeExtensions
    {

        public static bool IsDirectParentOf(this LocationType parent, LocationType child)
        {
            return (int)parent + 1 == (int)child;
        }
    }
}
