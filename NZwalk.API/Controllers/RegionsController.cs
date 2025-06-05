using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalk.API.CoustomActionFilter;
using NZwalk.API.Data;
using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;
using NZwalk.API.Repository;

namespace NZwalk.API.Controllers
{
    //https//localhost:portnuber/api/region
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbcontext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext nZWalksDbContext , IRegionRepository regionRepository , IMapper mapper)
        {
            this.dbcontext = nZWalksDbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        //GET : localhost:portnumber/api/
        [HttpGet]
        public async Task<IActionResult> GetRegion([FromQuery]string? filterOn, [FromQuery] string? filterQuery , [FromQuery] string? sortBy , [FromQuery] bool isAsc) // we can use other name than getregion() like  getall()
        {
            //get data from the database to domain model 
           //var regions = await dbcontext.Regions.ToListAsync(); using direct dbcontext

           var regions = await regionRepository.GetAllAsync(filterOn, filterQuery, sortBy , isAsc ); // using the region repository , repository pattern 


            //map domain to dtos manual mapping
            //var regionsDto = new List<RegionDTO>();

            //foreach (var region in regions)
            //{
            //    regionsDto.Add(new RegionDTO()
            //    { 
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });

            //}

            // map domain to dtos using automapper

            var regionsAutomapped = mapper.Map<List<RegionDto>>(regions);

            //return dto to client 

            return Ok(regionsAutomapped);
        }
        [HttpGet]
        [Route("{id:GUID}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //get data from database to domain model
            var regions = await regionRepository.GetRegionByIdAsync(id);
            if (regions == null)
            {
                return NotFound();
            }

            //map model to dto Manual 
            //RegionDTO regionDTO = new RegionDTO()
            //{
            //    Id = regions.Id,
            //    Name = regions.Name,
            //    Code = regions.Code,
            //    RegionImageUrl = regions.RegionImageUrl
            //};

            //map model to dto using automapper
            var regionDtoautomapped = mapper.Map<RegionDto>(regions);

           

            //return dto
            return Ok(regionDtoautomapped);
        }
        

        //POST to create new region 
        [HttpPost]
        [ValidateModel]
        public async  Task<IActionResult> Create([FromBody] AddRegionRequstDto requstDTO)
        {
            ////map or convert the request DTO to Domain model manual  
            //Region region = new Region()
            //{
            //    Code = requstDTO.Code,
            //    Name = requstDTO.Name,
            //    RegionImageUrl= requstDTO.RegionImageUrl
            //};
            //map or convert the request DTO to Domain model

            
            var region = mapper.Map<Region>(requstDTO);

            //use ef core to add region form model to database and save the changes 
            await regionRepository.CreateAsync(region);



            ////convert domain model to dto manual so that we can return as response
            //var RegionDto = new RegionDTO()
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImageUrl = region.RegionImageUrl
            //};

            //convert domain model to dto automapper 
            var RegionDto = mapper.Map<RegionDto>(region);

            //REST best practice is to use created at action result 
            return CreatedAtAction(nameof(GetRegionById), new { Id = region.Id }, RegionDto);
        }
        //update the region 
        // PUT : https://localhost:portnumber/api/region/{id}
        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateRegionRequstDto updateRegionRequstDto)
        {
            // checks if the resource is present or not 
            //var RegionDomainModel = await dbcontext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            //if(RegionDomainModel == null)
            //{
            //    return NotFound();
            //}
            //map the region requst dto to domain model 
            //RegionDomainModel.Name = updateRegionRequstDto.Name;
            //RegionDomainModel.Code = updateRegionRequstDto.Code;
            //RegionDomainModel.RegionImageUrl = updateRegionRequstDto.RegionImageUrl;

            ////savechanges 
            //await dbcontext.SaveChangesAsync();

            //using repository pattern 
            ////convert comming dto to domain model manual as our updateasync method need domain model 
            //Region RegionDomainModel = new()
            //{ 
            //    Name = updateRegionRequstDto.Name,
            //    Code = updateRegionRequstDto.Code,
            //    RegionImageUrl = updateRegionRequstDto.RegionImageUrl
            //};

            //convert comming dto to domain model
            Region RegionDomainModel = mapper.Map<Region>(updateRegionRequstDto);

            RegionDomainModel = await regionRepository.UpdateAsync(id, RegionDomainModel);

            if (RegionDomainModel == null)
            {
                return NotFound();
            }
            ////map the domain model to dto manual
            //var regionDto = new RegionDTO()
            //{
            //    Id = RegionDomainModel.Id,
            //    Code = RegionDomainModel.Code,
            //    Name = RegionDomainModel.Name,
            //    RegionImageUrl = RegionDomainModel.RegionImageUrl
            //};

            RegionDto regionDto = mapper.Map<RegionDto>(RegionDomainModel);

            return Ok(regionDto);
        }
        //DELETE : https://localhost:pn/api/region/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            //using direct dbcontext
            //var RegionDomainModel = await dbcontext.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            //if (RegionDomainModel == null)
            //{
            //    return NotFound();
            //}
            //delete the moddel
            //dbcontext.Remove(RegionDomainModel);
            //await dbcontext.SaveChangesAsync();

            //using repository pattern 
            var RegionDomainModel = await regionRepository.DeleteAsync(id);
            if(RegionDomainModel == null)
            {
                return NotFound();
            }
            ////manual mapping of regiondomainmodle to regiondto 
            //var regionDto = new RegionDTO()
            //{
            //    Id = RegionDomainModel.Id,
            //    Code = RegionDomainModel.Code,
            //    Name = RegionDomainModel.Name,
            //    RegionImageUrl = RegionDomainModel.RegionImageUrl
            //};
            //automapper mapping of regiondomainmodle to regiondto 
            var regionDto = mapper.Map<RegionDto>(RegionDomainModel);
            return Ok(regionDto);

        }
    }
}
