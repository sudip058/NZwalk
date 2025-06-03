using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;

namespace NZwalk.API.Repository
{
    public interface IWalkRepository
    {
        Task<Walks> CreateAsync(Walks walks);
        Task<List<Walks>> GetAllWalksAsync();
        Task<Walks?> GetWalksByIdAsync(Guid id);
        Task<Walks?> UpdateAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto);
        Task<Walks?> DeleteAsync(Guid id);
    }
}
