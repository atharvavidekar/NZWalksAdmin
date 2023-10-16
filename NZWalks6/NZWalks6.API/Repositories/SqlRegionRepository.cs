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

        public async Task<Region?> Delete(Guid id)
        {
           var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id==id);

            if (region == null)
                return null;


            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> Get(Guid id)
        {
            var region = await dbContext.Regions.FindAsync(id);

            if (region == null)
                return null;

            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            var regions = await dbContext.Regions.ToListAsync();

            return regions;
        }

        public async Task<Region?> Post(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> Put(Region region, Guid id)
        {
            var regionVar = await dbContext.Regions.FindAsync(id);

            if(regionVar==null)
                return null;

           regionVar.Code = region.Code;
            regionVar.Name = region.Name;
            regionVar.Area = region.Area;
            regionVar.Lat = region.Lat;
            regionVar.Long = region.Long;
            regionVar.Population=region.Population;
            await dbContext.SaveChangesAsync();

            return regionVar;
        }
    }
}
