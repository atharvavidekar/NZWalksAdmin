namespace NZWalks6.API.Models.DTO
{
    public class WalkAddDto
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Guid RegionId { get; set; }
    }
}
