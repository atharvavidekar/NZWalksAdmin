using NZWalks6.API.Models.Domains;
using System.Collections;

namespace NZWalks6.API.Repositories
{
    public interface IRegionRepository
    {

        Task<IEnumerable<Region>> GetAllAsync();
    }
}
