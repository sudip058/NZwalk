using NZwalk.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NZwalk.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Discription { get; set; }
        [Required]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }

        
    }
}
