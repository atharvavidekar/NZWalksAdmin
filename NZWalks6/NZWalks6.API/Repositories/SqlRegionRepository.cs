using Microsoft.EntityFrameworkCore;
using NZWalks6.API.Data;
using NZWalks6.API.Models.Domains;
using System.Collections;

namespace NZWalks6.API.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SqlRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            var regions = await dbContext.Regions.ToListAsync();

            return regions;
        }
    }
}
