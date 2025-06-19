using MediatR;
using Octovis.Location.Application.Authorization;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Domain.AggregateModels.Addresses;
using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;
using Octovis.User.Conract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Octovis.Location.Application.UseCases.Commands.CreateAddress
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand,bool>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IAuthorizationService _authService;
        private readonly ILocationUnitOfWork _unitOfWork;

   
        public AddAddressCommandHandler(IAddressRepository addressRepository, ILocationUnitOfWork unitOfWork, IUserService userService, IAuthorizationService authService)
        {
            _addressRepository = addressRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<bool> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {

            //_authService.CheckPermission(Claims.CreateAddress);

            var address = Address.Create(request.CountryId, request.CityId, request.DistrictId, request.Latitude, request.Longitude);

            await _addressRepository.AddAsync(address, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
         
        }

    }
}
