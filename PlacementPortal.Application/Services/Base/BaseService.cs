using AutoMapper;
using PlacementPortal.Application.Common;
using PlacementPortal.Application.Interfaces.Repositories;

namespace PlacementPortal.Application.Services.Base
{
    public abstract class BaseService
    {
        protected IUnitOfWork UnitOfWork;
        protected IMapper Mapper;
        protected IDateTimeProvider DateTimeProvider;
        public BaseService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           IDateTimeProvider dateTimeProvider)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
            DateTimeProvider = dateTimeProvider;
        }
    }
}
