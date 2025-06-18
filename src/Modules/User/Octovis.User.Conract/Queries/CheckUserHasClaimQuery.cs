using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.User.Conract.Queries
{
    public class CheckUserHasClaimQuery:IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid ClaimId { get; set; }
    }
}
