using System.ComponentModel.DataAnnotations;

namespace NZwalk.API.Models.DTO
{
    public class UpdateRegionRequstDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code is to be min 3 charectrer long")]
        [MaxLength(3, ErrorMessage = "Code is to be max 3 charecter long")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
