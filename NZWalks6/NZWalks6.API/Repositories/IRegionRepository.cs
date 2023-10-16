using NZWalks6.API.Models.Domains;
using System.Collections;

namespace NZWalks6.API.Repositories
{
    public interface IRegionRepository
    {

        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region?> Get(Guid id);

        Task<Region> Post(Region region);

        Task<Region?> Delete(Guid id);

        Task<Region?> Put(Region region,Guid id);

    }
}
