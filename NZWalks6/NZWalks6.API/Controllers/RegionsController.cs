using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks6.API.Models.Domains;
using NZWalks6.API.Models.DTO;
using NZWalks6.API.Repositories;

namespace NZWalks6.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllData()
        {
            

            var regions = await regionRepository.GetAllAsync();
          //  var regionsDto = new List<Region>();
            //regions.ToList().ForEach(Region => {

            //    regionsDto.Add(
            //        new Region
            //        {
            //            Id = Region.Id,
            //            Code = Region.Code,
            //            Name = Region.Name,
            //            Area = Region.Area,
            //            Lat = Region.Lat,
            //            Long = Region.Long,
            //            Population = Region.Population,
            //        }
            //        );

            //});
           var regionsDto =  mapper.Map<List<RegionsDtos>>(regions);

            return Ok(regionsDto);

    }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetByIdAsync")]
        
        public async Task<IActionResult >GetByIdAsync([FromRoute] Guid id)
        {
            var region=await regionRepository.Get(id);

            if (region == null)
                return NotFound();

            else
                return Ok(mapper.Map<RegionsDtos>(region));

        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RegionAddDto regionDto)
        {

            // validating input
            if (  !(ValidateCreateAsync(regionDto)) );
            return BadRequest(ModelState);

            var region = mapper.Map<Region>(regionDto);

            var regionVar= await regionRepository.Post(region);

            //return Ok(mapper.Map<RegionAddDto>(regionVar));
            return CreatedAtAction(nameof(GetByIdAsync), new { id = regionVar.Id }, mapper.Map<RegionsDtos>(regionVar));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAync([FromRoute] Guid id)
        { 
            var region = await regionRepository.Delete(id);

            if (region == null)
                return NotFound();

            return Ok(mapper.Map<RegionsDtos>(region));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> PutAsync([FromBody] RegionAddDto regionAddDto, [FromRoute] Guid id)
        {
           var region = mapper.Map<Region>(regionAddDto);

           region=await regionRepository.Put(region, id);

            if (region == null)
            {
                return NotFound();  
            }

            return Ok(mapper.Map<RegionsDtos>(region));
        }
        #region private Methods

       
        private bool ValidateCreateAsync(RegionAddDto regionDto)
        {

            if (regionDto==null)
            {

                ModelState.AddModelError(nameof(regionDto), $"The input {nameof(regionDto)} is invalid as it is blank");
                return false;
            }

            if (string.IsNullOrWhiteSpace(regionDto.Code))
            {

                ModelState.AddModelError(nameof(regionDto.Code), $"The input {nameof(regionDto.Code)} is invalid as it has whitespace or is blank or null");
            }

            if (string.IsNullOrWhiteSpace(regionDto.Name))
            {

                ModelState.AddModelError(nameof(regionDto.Name), $"The input {nameof(regionDto.Name)} is invalid as it has whitespace or is blank or null");
            }

            if (regionDto.Area<=0)
            {

                ModelState.AddModelError(nameof(regionDto.Area), $"The input {nameof(regionDto.Area)} is invalid as it cannot be negative or zero");
            }

            if (regionDto.Lat <= 0)
            {

                ModelState.AddModelError(nameof(regionDto.Lat), $"The input {nameof(regionDto.Lat)} is invalid as it cannot be negative or zero");
            }

            if (regionDto.Long <= 0)
            {

                ModelState.AddModelError(nameof(regionDto.Long), $"The input {nameof(regionDto.Long)} is invalid as it cannot be negative or zero");
            }

            if (regionDto.Population < 0)
            {

                ModelState.AddModelError(nameof(regionDto.Population), $"The input {nameof(regionDto.Population)} is invalid as it cannot be negative");
            }
            if (ModelState.ErrorCount > 0)
                return false;

            return true;

        }
        #endregion
    }
}
