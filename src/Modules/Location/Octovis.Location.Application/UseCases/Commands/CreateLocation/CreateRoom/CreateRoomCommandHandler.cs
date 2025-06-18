using MediatR;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {

        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateRoomCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {

            var location = Domain.AggregateModels.Locations.Location.Create(request.ParentId, request.LocationType, request.Description, request.Name);

            var res = await _locationRepository.AddAsync(location, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return res;
        }
    }
}
