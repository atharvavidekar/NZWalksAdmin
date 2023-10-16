using AutoMapper;
using NZWalks6.API.Models.DTO;

namespace NZWalks6.API.Profiles
{
    public class WalkDifficultyProfile :Profile
    {

        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domains.WalkDifficulty, Models.DTO.WalkDifficultyDto>()
                .ReverseMap();
            CreateMap<Models.Domains.WalkDifficulty, Models.DTO.AddWalkDifficultyDto>()
                .ReverseMap();


            /*ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))*/
        }
    }
}
