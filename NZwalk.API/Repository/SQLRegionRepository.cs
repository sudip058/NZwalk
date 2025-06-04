using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZwalk.API.Data;
using NZwalk.API.Models.Domain;

namespace NZwalk.API.Repository
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync(string? filterOn, string? filterQuery, string? sortBy, bool isAsc = true)
        {
            //return await dbContext.Regions.ToListAsync();

            //filtering
            var region = dbContext.Regions.AsQueryable();
            if(!string.IsNullOrWhiteSpace(filterOn)&&!string.IsNullOrWhiteSpace(filterQuery))
            {
                if (filterOn.Contains("Name",StringComparison.OrdinalIgnoreCase))
                {
                    region = region.Where(x => x.Name.ToLower().Contains(filterQuery.ToLower()));
                }
                
            }
            //sorting
            if(!string.IsNullOrWhiteSpace(sortBy))
            {
                if(sortBy.Contains("Name",StringComparison.OrdinalIgnoreCase))
                {
                    region = isAsc ? region.OrderBy(x => x.Name) : region.OrderByDescending(x=>x.Name);
                }
            }

            return await region.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var ExistingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (ExistingRegion == null)
            {
                return null;
            }
            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.RegionImageUrl = region.RegionImageUrl;
            await dbContext.SaveChangesAsync();
            return ExistingRegion;
        }
    }
}
