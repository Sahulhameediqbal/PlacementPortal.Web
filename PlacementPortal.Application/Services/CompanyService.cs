using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Application.Interfaces.Services;
using PlacementPortal.Application.Services.Base;

namespace PlacementPortal.Application.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork, 
                              IMapper mapper, 
                              IDateTimeProvider dateTimeProvider) : base(unitOfWork, mapper, dateTimeProvider)
        {
        }
    }
}
