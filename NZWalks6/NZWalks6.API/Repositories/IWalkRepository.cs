using NZWalks6.API.Models.Domains;

namespace NZWalks6.API.Repositories
{
    public interface IWalkRepository
    {

        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GeByIdAsync(Guid id);

        Task<Walk> CreateAsync(Walk walk);

        Task<Walk?> DeleteByIdAsync(Guid id);


        Task<Walk> UpdateAsync(Guid id, Walk walk);

    }
}
