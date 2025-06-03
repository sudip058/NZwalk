using Microsoft.EntityFrameworkCore;
using NZwalk.API.Data;
using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;

namespace NZwalk.API.Repository
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
            await dbContext.Walks.AddAsync(walks);
            await dbContext.SaveChangesAsync();
            return walks;
        }

        public async Task<Walks?> DeleteAsync(Guid id)
        {
            var walks = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walks == null)
            {
                return null;
            }
            dbContext.Walks.Remove(walks);
            await dbContext.SaveChangesAsync();
            return walks;

        }

        public async Task<List<Walks>> GetAllWalksAsync()
        {
            return await dbContext.Walks
     .Include(nameof(Walks.Difficulty))
     .Include(nameof(Walks.Region))
     .ToListAsync();
        }

        public async Task<Walks?> GetWalksByIdAsync(Guid id)
        {
            return await dbContext.Walks
                        .Include(nameof(Walks.Difficulty))
                        .Include(nameof(Walks.Region))
                        .FirstOrDefaultAsync(x => x.Id == id);    
        }

        public async Task<Walks?> UpdateAsync(Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            //fetch data from database using efcore 
            var walksDomain = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if(walksDomain == null)
            {
                return null;
            }
            walksDomain.Id = id;
            walksDomain.Name = updateWalkRequestDto.Name;
            walksDomain.Discription = updateWalkRequestDto.Discription;
            walksDomain.LengthInKm = updateWalkRequestDto.LengthInKm;
            walksDomain.WalkImageUrl = updateWalkRequestDto.WalkImageUrl;
            walksDomain.RegionId = updateWalkRequestDto.RegionId;
            walksDomain.DifficultyId = updateWalkRequestDto.DifficultyId;
            await dbContext.SaveChangesAsync();
            return walksDomain;
        }
    }
}
