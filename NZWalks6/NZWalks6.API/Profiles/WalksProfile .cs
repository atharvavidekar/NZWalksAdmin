using AutoMapper;
using NZWalks6.API.Models.DTO;

namespace NZWalks6.API.Profiles
{
    public class WalksProfile :Profile
    {

        public WalksProfile()
        {
           
            CreateMap<Models.Domains.Walk, Models.DTO.WalkDto>()
                .ReverseMap();
            /*ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))*/
            CreateMap<Models.Domains.WalkDifficulty, Models.DTO.WalkDifficultyDto>()
                .ReverseMap();
            CreateMap<Models.Domains.Walk, Models.DTO.WalkAddDto>()
                .ReverseMap();
            CreateMap<Models.Domains.Walk, Models.DTO.WalkUpdateDto>()
               .ReverseMap();

        }
    }
}
