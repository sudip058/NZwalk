using Microsoft.EntityFrameworkCore;
using NZwalk.API.Models.Domain;

namespace NZwalk.API.Data
{
    public class NZWalksDbContext :DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Difficulty> difficulties = new List<Difficulty>()
            {
                new Difficulty() { 
                    Id = Guid.Parse("ef63833b-47d7-4ab3-873a-3ad68444973b"),
                    Name = "Easy"
                },
                new Difficulty() {
                    Id = Guid.Parse("0a9bd599-69e7-4903-a0e5-3f51117192f1"),
                    Name = "Medium"
                },
                new Difficulty() {
                    Id = Guid.Parse("c6c57173-772f-452a-bb7d-20e8d043c03b"),
                    Name = "Hard"
                }
            };

            List<Region> regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("2caea0ac-28de-4e21-bef5-5df893afbc23"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "http://www.gettyimages.com/detail/503939548"
                },
                new Region()
                {
                    Id = Guid.Parse("8b872e8c-1ba1-4fa1-9cbf-04626675fe22"),
                    Name = "Aukland",
                    Code = "AKL",
                    RegionImageUrl = "https://www.alltrails.com/new-zealand/auckland/walking"
                },
                new Region()
                {
                    Id = Guid.Parse("e7020c0f-931b-4fde-99bf-cbdff85c8c8f"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://www.eaxmple.com/bayofplenty/images"
                },
                new Region()
                {
                    Id = Guid.Parse("ca769d6b-19b6-45ba-ac37-74730d0eb1d0"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://www.eaxmple.com/Northland/images"
                },
                new Region()
                {
                    Id = Guid.Parse("d183a2fd-7256-4781-ad94-ca54c3e68277"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://www.eaxmple.com/Southland/images"
                },
                new Region()
                {
                    Id = Guid.Parse("a5300ed1-2603-4eb6-b810-c702f4a9c840"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://www.eaxmple.com/Wellington/images"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
        }

    }
}
