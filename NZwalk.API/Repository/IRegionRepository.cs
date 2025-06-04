using NZwalk.API.Models.Domain;

namespace NZwalk.API.Repository
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(string? filterOn , string? filterQuery , string? sortBy , bool isAsc = true);
        Task<Region?> GetRegionByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);

    }
}
