﻿using AutoMapper;
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
    }
}
