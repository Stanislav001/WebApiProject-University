﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ModelServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryConroller : ControllerBase
    {
        public CountryConroller(ICountryService countryService)
        {
            CountryService = countryService;
        }
        public ICountryService CountryService { get; }

        [HttpGet]
        [Route("companies")]
        public IActionResult GetCompanies()
        {
            var result = CountryService.GetAllCountries();
            return Ok(result);
        }

        [HttpGet]
        [Route("companyByName")]
        public IActionResult GetCompnayByName(string name)
        {
            var result = CountryService.SearchCountryByName(name);
            return Ok(result);
        }

        [HttpGet]
        [Route("totalOrder")]
        public IActionResult GetTotalOrdersByCountry()
        {
            var result = CountryService.GetTotalOrdersByCountry();
            return Ok(result);
        }
    }
}
