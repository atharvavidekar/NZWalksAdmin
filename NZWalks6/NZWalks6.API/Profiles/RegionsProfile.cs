using AutoMapper;

namespace NZWalks6.API.Profiles
{
    public class RegionsProfile :Profile
    {

        public RegionsProfile()
        {
            CreateMap<Models.Domains.Region, Models.DTO.RegionsDtos>()
                .ReverseMap();
                /*ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))*/
        }
    }
}
