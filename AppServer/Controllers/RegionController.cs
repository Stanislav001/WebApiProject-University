using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.ModelServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public RegionController(IRegionService region)
        {
            Region = region;

        }
        public IRegionService Region { get; }

        [HttpGet, Authorize]
        public IActionResult GetRegions()
        {
            var result = Region.GetAllRegions();
            return Ok(result);
        }

        [HttpGet]
        [Route("regionByName")]
        public IActionResult GetRegionByName(string name)
        {
            var result = Region.SearchRegionByName(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("topSales")]
        public IActionResult TopSalesByTotalProfit()
        {
            var result = Region.TopSalesByTotalProfit();
            return Ok(result);
        }
    }
}
