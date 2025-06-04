using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalk.API.CoustomActionFilter;
using NZwalk.API.Models.Domain;
using NZwalk.API.Models.DTO;
using NZwalk.API.Repository;

namespace NZwalk.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper , IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
            //map dto to domain model
            var WalkDomainModel =  mapper.Map<Walks>(addWalkRequestDto);

            //use ef core to add walk form model to database and save the changes using walkrepository 
             await walkRepository.CreateAsync(WalkDomainModel);

            //map domain model to dto 
            return Ok(mapper.Map<WalkDto>(WalkDomainModel));
        }
        [HttpGet]
        //GET : localhost:portnumber/api/Walk?filterOn=Name&&filterQuery=sth&&sortBy=Name&&isAsc=True
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery, [FromQuery] string? sortBy , [FromQuery] bool isAsc , [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
           var walksDomain =  await walkRepository.GetAllWalksAsync(filterOn,filterQuery,sortBy,isAsc, pageNumber , pageSize);
            //map the model to walkdto
            var walkDtos = mapper.Map<List<WalkDto>>(walksDomain);
            return Ok(walkDtos);
         
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalksById([FromRoute] Guid id)
        {
            //get model first using repository
            var Walk = await walkRepository.GetWalksByIdAsync(id);

            if (Walk == null)
            {
                return NotFound();
            }

            //map the model to the WalkDto

            return Ok(mapper.Map<WalkDto>(Walk));
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //if(!ModelState.IsValid)
            //{ 
            //    return BadRequest(ModelState); as coustomfilter attribute named as ValidateModel is used 
            //}
            //update the data using repository 
            var WalkDomain = await walkRepository.UpdateAsync(id, updateWalkRequestDto);

            if (WalkDomain == null)
            {
                return NotFound();
            }

            //convert walk domain to walk dto and return 

            var WalkDto = mapper.Map<WalkDto>(WalkDomain);

            return Ok(WalkDto);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
           var walksDomain = await walkRepository.DeleteAsync(id);
            if (walksDomain == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walksDomain));
        }

    }
}
