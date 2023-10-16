using NZWalks6.API.Models.Domains;

namespace NZWalks6.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
         Task<IEnumerable<WalkDifficulty>> GetAllAsync();

         Task<WalkDifficulty?> GetByIdAsync(Guid id);

        Task<WalkDifficulty> CreateAsync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty?> DeleteAsync(Guid id);

        Task<WalkDifficulty?> UpdateAsync(WalkDifficulty walkDifficulty,Guid id);


    }
}
