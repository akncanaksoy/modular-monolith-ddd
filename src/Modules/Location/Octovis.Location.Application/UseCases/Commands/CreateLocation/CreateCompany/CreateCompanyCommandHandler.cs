using MediatR;
using Octovis.Location.Application.Authorization;
using Octovis.Location.Application.Interfaces.Repositories;
using Octovis.Location.Application.Interfaces.Services;
using Octovis.Location.Domain.AggregateModels.Locations;
using Octovis.SharedKernel.Domain;
using Octovis.SharedKernel.Exceptions;


namespace Octovis.Location.Application.UseCases.Commands.CreateLocation.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, bool>
    {
        private readonly IAuthorizationService _authService;
        private readonly ILocationRepository _locationRepository;
        private readonly ILocationUnitOfWork _unitOfWork;

        public CreateCompanyCommandHandler(ILocationRepository locationRepository, ILocationUnitOfWork unitOfWork, IAuthorizationService authService)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
           // _authService.CheckPermission(Claims.CreateCompany);

            var parentLocation = await _locationRepository.GetByParentIdAsync(request.ParentId, cancellationToken);
            if (parentLocation == null) throw new NotFoundExpcetion();

            //parentLocation.CanBeChildOfOrThrow(parentLocation.Type);

            var location = Domain.AggregateModels.Locations.Location.Create(request.ParentId, request.LocationType, request.Description, request.Name);

            var company = Company.Create(location.Id,request.Email,request.Phone,request.AddressType,request.AddressId);

            location.SetCompany(company);

            await _locationRepository.AddAsync(location, cancellationToken);

            var result = await _unitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;

        }
    }
}
