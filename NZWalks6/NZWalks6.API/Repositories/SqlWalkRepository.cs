using Microsoft.EntityFrameworkCore;
using NZWalks6.API.Data;
using NZWalks6.API.Models.Domains;

namespace NZWalks6.API.Repositories
{

   
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
           await dbContext.Walks.AddAsync(walk);

           await dbContext.SaveChangesAsync();
            
            return walk;
            



        }

        public async Task<Walk?> DeleteByIdAsync(Guid id)
        {
            var walk = await dbContext.Walks.FindAsync(id);
            if (walk == null)
                return null;

            dbContext.Walks.Remove(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }

      

        public async Task<Walk?> GeByIdAsync(Guid id)
        {
            var walk =await dbContext.Walks
                .Include(x=>x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x=>x.Id==id);

            if (walk == null)
                return null;

            return walk;
        }

        public  async Task<List<Walk>> GetAllAsync()
        {
          var walks = await dbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();

            return walks;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var walkVar =await dbContext.Walks .FindAsync(id);

            if (walkVar == null)
                return null;

            walkVar.Name = walk.Name;
            walkVar.Length = walk.Length;
            await dbContext.SaveChangesAsync();

            return walkVar;

        }
    }
}
