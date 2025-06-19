using MediatR;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateRegion
{
    public class CreateRegionCommandHandler : IRequestHandler<CreateRegionCommand, bool>
    {

        private readonly ILocationRepository _locationRepository;
        private readonly ILocationUnitOfWork _unitOfWork;

        public CreateRegionCommandHandler(ILocationRepository locationRepository, ILocationUnitOfWork unitOfWork)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateRegionCommand request, CancellationToken cancellationToken)
        {

            var location = Domain.AggregateModels.Locations.Location.Create(request.ParentId, request.LocationType, request.Description, request.Name);

            var res = await _locationRepository.AddAsync(location, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}
