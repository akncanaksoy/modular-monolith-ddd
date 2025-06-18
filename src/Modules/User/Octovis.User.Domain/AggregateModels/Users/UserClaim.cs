using Octovis.SharedKernel.Domain;
using Octovis.User.Domain.AggregateModels.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Domain.AggregateModels.Users
{
    public class UserClaim : Entity
    {
        public Guid UserId { get; private set; }
        public Guid ClaimId { get; private set; }



        private UserClaim() { }

        public UserClaim(Guid userId, Guid claimId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            ClaimId = claimId;
        }
    }

}
