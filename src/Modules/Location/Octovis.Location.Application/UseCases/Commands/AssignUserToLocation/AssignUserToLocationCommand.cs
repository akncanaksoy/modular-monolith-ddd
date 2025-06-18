using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.AssignUserToLocation
{
    public class AssignUserToLocationCommand :IRequest<bool>
    {
        public Guid UserId { get; set; }
        public Guid LocationId { get; set; }


        public AssignUserToLocationCommand(Guid userId, Guid locationId)
        {
            UserId = userId;
            LocationId = locationId;
        }
    }
}
