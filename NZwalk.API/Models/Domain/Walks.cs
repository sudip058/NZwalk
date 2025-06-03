﻿namespace NZwalk.API.Models.Domain
{
    public class Walks
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        //navigation property 
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        public Difficulty? Difficulty { get; set; }
        public Region? Region { get; set; }

    }
}
