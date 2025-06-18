using Octovis.SharedKernel.Domain;
using Octovis.User.Domain.AggregateModels.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Domain.AggregateModels.Roles
{
    public class RoleClaim : Entity
    {
        public Guid RoleId { get; private set; }
        public Guid ClaimId { get; private set; }

        private RoleClaim() { }

        public RoleClaim(Guid roleId, Guid claimId)
        {
            RoleId = roleId;
            ClaimId = claimId;
        }
    }
}
