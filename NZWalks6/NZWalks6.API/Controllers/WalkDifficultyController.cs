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
    public class WalkDifficultyController : ControllerBase
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository,IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var walkDifficulties = await walkDifficultyRepository.GetAllAsync();
            return Ok(mapper.Map < IEnumerable<WalkDifficultyDto>>(walkDifficulties));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        { 
            var walkDifficulty = await walkDifficultyRepository.GetByIdAsync(id); 
            if(walkDifficulty==null)
                return NotFound();

            return Ok(mapper.Map<WalkDifficultyDto>(walkDifficulty));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AddWalkDifficultyDto addWalkDiffDto)
        {

          var walkDiffDomain =   mapper.Map<WalkDifficulty>(addWalkDiffDto);

            walkDiffDomain=await walkDifficultyRepository.CreateAsync(walkDiffDomain);

            var walkDifficultiesDto = mapper.Map<WalkDifficultyDto>(walkDiffDomain);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = walkDifficultiesDto.Id }, walkDifficultiesDto);

        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]Guid id)
        { 
               var walkDiff = await walkDifficultyRepository.DeleteAsync(id);

            if(walkDiff==null) return NotFound();

            return Ok(walkDiff);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] AddWalkDifficultyDto walkDifficultyDto)
        {
            var walkDiff = await walkDifficultyRepository.UpdateAsync(mapper.Map<WalkDifficulty>(walkDifficultyDto), id);
            if (walkDiff == null) return NotFound();

            return Ok(walkDiff);
        }

    }
}
