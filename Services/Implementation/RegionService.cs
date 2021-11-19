using AutoMapper;
using Date;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class RegionService : IRegionService
    {
        public RegionService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            ApplicationDbContext = applicationDbContext;
            Mapper = mapper;
        }
        public ApplicationDbContext ApplicationDbContext { get; }
        public IMapper Mapper { get; }

        public List<RegionViewModel> GetAllRegions()
        {
            List<Region> region = ApplicationDbContext.Regions
                                  .Select(x => new Region()
                                  {
                                      RegionName = x.RegionName
                                  }).ToList();

            List<RegionViewModel> regions = Mapper.Map<List<RegionViewModel>>(region);
            return regions;
        }
    }
}
