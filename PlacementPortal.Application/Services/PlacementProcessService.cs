using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;

namespace PlacementPortal.Application.Services
{
    public class PlacementProcessService : BaseService, IPlacementProcessService
    {
        public PlacementProcessService(IUnitOfWork unitOfWork,
                                       IMapper mapper,
                                       IDateTimeProvider dateTimeProvider) : base(unitOfWork, mapper, dateTimeProvider)
        {

        }
    }
}
