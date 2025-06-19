using MediatR;
using Octovis.Location.Application.Authorization;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Domain.AggregateModels.Locations;
using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateArea
{
    public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, bool>
    {
        private readonly IAuthorizationService _authService;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationUnitOfWork _unitOfWork;

        public CreateAreaCommandHandler(ILocationRepository locationRepository, ILocationUnitOfWork unitOfWork, IAuthorizationService authService)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<bool> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {

            _authService.CheckPermission(Claims.CreateArea);

            var parentLocation = await _locationRepository.GetByParentIdAsync(request.ParentId, cancellationToken);
            if (parentLocation == null) throw new NotFoundExpcetion();

            parentLocation.CanBeChildOfOrThrow(parentLocation.Type);

            var location = Domain.AggregateModels.Locations.Location.Create(request.ParentId, request.LocationType, request.Description, request.Name);

            var area = new Area(location.Id);

            location.SetArea(area);

            await _locationRepository.AddAsync(location, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
