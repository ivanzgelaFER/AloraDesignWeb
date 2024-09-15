using AutoMapper;
using AloraDesign.Domain.DTOs;
using AloraDesign.Domain.Models;

namespace AloraDesign.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NewResidentialBuildingDto, ResidentialBuilding>().ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ResidentialBuilding, ResidentialBuildingDto>();
        }
    }
}
