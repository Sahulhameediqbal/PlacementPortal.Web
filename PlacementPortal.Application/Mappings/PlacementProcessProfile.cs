using AutoMapper;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Model.Models;

namespace PlacementPortal.Application.Mappings
{
    public class PlacementProcessProfile:Profile
    {
        public PlacementProcessProfile()
        {
            CreateMap<PlacementProcessModel, PlacementProcess>()
                   .ReverseMap();
        }
    }
}
