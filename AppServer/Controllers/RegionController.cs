using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
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
        public IActionResult GetCompanies()
        {
            var result = Region.GetAllRegions();
            return Ok(result);
        }
    }
}
