using AutoMapper;
using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;

namespace NZwalk.API.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequstDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequstDto, Region>().ReverseMap();
            CreateMap<Walks, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walks , WalkDto>().ReverseMap();
            CreateMap<Walks , UpdateWalkRequestDto>().ReverseMap();
            CreateMap<Difficulty, DificultyDto>().ReverseMap();
        }
    }
}
