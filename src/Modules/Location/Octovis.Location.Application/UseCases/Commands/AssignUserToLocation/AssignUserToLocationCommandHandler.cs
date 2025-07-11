﻿using MediatR;
using Octovis.Location.Application.Authorization;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;
using Octovis.User.Conract.Queries;

namespace Octovis.Location.Application.UseCases.Commands.AssignUserToLocation
{
    public class AssignUserToLocationCommandHandler : IRequestHandler<AssignUserToLocationCommand, bool>
    {
        private readonly IAuthorizationService _authService;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public AssignUserToLocationCommandHandler(ILocationRepository locationRepository, ILocationUnitOfWork unitOfWork, IUserService userService, IAuthorizationService authService)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _authService = authService;
        }

        public async Task<bool> Handle(AssignUserToLocationCommand request, CancellationToken cancellationToken)
        {

            // _authService.CheckPermission(Claims.AssignUserToLocation);

            // belki burada sonra  o locationa ait mi diye bakılır. 

           await _unitOfWork.BeginTransactionAsync();

            try
            {


                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
            }
            var userDto = await _userService.GetUserByIdAsync(new GetUserByIdQuery { UserId = request.UserId });

            if (userDto == null) throw new NotFoundExpcetion($"User {request.UserId.ToString()} not found"); 

            var location = await _locationRepository.GetByIdAsync(request.LocationId, cancellationToken);
            
            if (location == null) throw new NotFoundExpcetion($"Location {request.LocationId.ToString()} not found");

            location.AddUser(request.UserId,userDto.UserName);

            await _locationRepository.AddAsync(location, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;

        }
    }
}
