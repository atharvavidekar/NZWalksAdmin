using Microsoft.EntityFrameworkCore;
using NZWalks6.API.Data;
using NZWalks6.API.Models.Domains;

namespace NZWalks6.API.Repositories
{
    public class SqlWalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlWalkDifficultyRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<WalkDifficulty> CreateAsync(WalkDifficulty walkDifficulty)
        {
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty?> DeleteAsync(Guid id)
        {
            var walkDifficulty = await dbContext.WalkDifficulty.FindAsync(id);

            if(walkDifficulty==null)
                return null;

             dbContext.WalkDifficulty.Remove(walkDifficulty);
            await dbContext.SaveChangesAsync();

            return walkDifficulty;
           
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty?> GetByIdAsync(Guid id)
        {
           var walkDifficulty= await dbContext.WalkDifficulty.FindAsync(id);
            if (walkDifficulty == null) 
            {
                return null;
            }

            return walkDifficulty;
        }

        public async Task<WalkDifficulty?> UpdateAsync(WalkDifficulty walkDifficulty, Guid id)
        {
            var walkDifficultyVar = await dbContext.WalkDifficulty.FindAsync(id);
            if (walkDifficultyVar == null)
            {
                return null;
            }

            walkDifficultyVar.Code= walkDifficulty.Code;
            await dbContext.SaveChangesAsync();

            return walkDifficultyVar;


        }
    }
}
