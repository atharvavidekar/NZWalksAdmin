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
    }
}
