using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks6.API.Models.Domains;
using NZWalks6.API.Models.DTO;
using NZWalks6.API.Repositories;

namespace NZWalks6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walks = await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walks));
        }
        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromRoute]Guid id)
        {
            var walk = await walkRepository.GeByIdAsync(id);

            if(walk==null)
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] WalkAddDto walk)
        {
            var walkDomain =mapper.Map<Walk>(walk);

            walkDomain=await walkRepository.CreateAsync(walkDomain);

            var walkDto = mapper.Map<WalkDto>(walkDomain);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = walkDto.Id }, walkDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var walk =await walkRepository.DeleteByIdAsync(id);
            if(walk==null) 
                return NotFound();

            return Ok(mapper.Map<WalkDto>(walk));

        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromBody] WalkUpdateDto walk, [FromRoute] Guid id)
        {

            var walkDiffDomain = mapper.Map<WalkDifficultyDto>(walk);
            if(walkDiffDomain==null)
                return NotFound();

            return Ok(mapper.Map<WalkDifficultyDto>(walkDiffDomain));
        }


    }
}
