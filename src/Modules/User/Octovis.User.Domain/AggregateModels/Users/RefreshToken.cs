using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Domain.AggregateModels.Users
{
    public class RefreshToken : Entity
    {
        public string Token { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsRevoked { get; private set; }
        public string ReplacedByToken { get; private set; }

        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public bool IsActive => !IsRevoked && !IsExpired;

        public void Revoke(string replacedByToken) {
        
        }

  
    }

}
