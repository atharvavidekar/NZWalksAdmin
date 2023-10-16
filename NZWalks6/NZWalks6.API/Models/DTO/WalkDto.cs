using NZWalks6.API.Models.Domains;

namespace NZWalks6.API.Models.DTO
{
    public class WalkDto
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }

        public double Length { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Guid RegionId { get; set; }

        //navigation properties
        public Region Region { get; set; }

        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
