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

namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateDealer
{
    public class CreateDealerCommandHandler : IRequestHandler<CreateDealerCommand, bool>
    {
        private readonly IAuthorizationService _authService;
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDealerCommandHandler(ILocationRepository locationRepository, IUnitOfWork unitOfWork, IAuthorizationService authService)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<bool> Handle(CreateDealerCommand request, CancellationToken cancellationToken)
        {

            //_authService.CheckPermission(Claims.CreateDealer);
           
            var location = Domain.AggregateModels.Locations.Location.Create(Guid.Empty, request.LocationType, request.Description, request.Name);

            var dealer = Dealer.Create(location.Id, request.Email, request.Phone, request.AddressType, request.AddressId);

            location.SetDealer(dealer);

            await _locationRepository.AddAsync(location, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
