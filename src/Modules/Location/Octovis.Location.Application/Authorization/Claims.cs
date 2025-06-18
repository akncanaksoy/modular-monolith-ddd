using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.Authorization
{
    public static class Claims
    {
        public const string CreateAddress = "Address.Create";
        
        
        public const string CreateArea = "Location.Create.Area";
        public const string CreateDealer = "Location.Create.Dealer";
        public const string CreateCompany = "Location.Create.Company";


        public const string AssignUserToLocation = "Location.User.Add";




    }
}
