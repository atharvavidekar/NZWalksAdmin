using AutoMapper;
using NZWalks6.API.Models.DTO;

namespace NZWalks6.API.Profiles
{
    public class RegionsProfile :Profile
    {

        public RegionsProfile()
        {
            CreateMap<Models.Domains.Region, Models.DTO.RegionsDtos>()
                .ReverseMap();
            CreateMap<Models.Domains.Region, Models.DTO.RegionAddDto>()
                .ReverseMap();
           
            /*ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))*/
        }
    }
}
