using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;

namespace NZwalk.API.Repository
{
    public interface IWalkRepository
    {
        Task<Walks> CreateAsync(Walks walks);
        Task<List<Walks>> GetAllWalksAsync(string? filterOn, string? filterQuery ,string? sortBy , bool isAsc = true , int pageNumber = 1 , int pageSize = 100);
        Task<Walks?> GetWalksByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto);
        Task<Walks?> DeleteAsync(Guid id);
    }
}
