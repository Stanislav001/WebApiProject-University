using AutoMapper;
using Date;
using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class DatabaseTransfer : IDatabaseTransfer
    {
        public DatabaseTransfer(ApplicationDbContext appDbContext, IMapper mapper)
        {
            ApplicationDbContext = appDbContext;
            Mapper = mapper;
        }

        public ApplicationDbContext ApplicationDbContext { get; }
        public IMapper Mapper { get; }

        public async Task TransferAsync(List<RegionViewModel> regions, string fileDate)
        {
            var data = Mapper.Map<List<Region>>(regions);

            var currentlyAddedInDb = ApplicationDbContext.Regions.Include(x => x.Countries)
                                     .Select(x => new
                                     {
                                         RegionName = x.RegionName,
                                         CountryName = x.Countries.Select(d => d.CountryName).ToList()
                                     }).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                var region = currentlyAddedInDb.FirstOrDefault(x => x.RegionName == data[i].RegionName);
                // Region check
                if (region != null)
                {
                    // Country check
                    for (int j = 0; j < data[i].Countries.Count; j++)
                    {
                        if (region.CountryName.FirstOrDefault(x => x == data[i].Countries[j].CountryName) != null)
                        {
                            var countrytDb = ApplicationDbContext.Countries.Include(x => x.Orders).FirstOrDefault(x => x.CountryName == data[i].Countries[j].CountryName);

                            countrytDb.Orders.AddRange(data[i].Countries[j].Orders);
                        }
                        else
                        {
                            var dbRegion = ApplicationDbContext.Regions.Include(x => x.Countries).FirstOrDefault(x => x.RegionName == data[i].RegionName);
                            dbRegion.Countries.Add(data[i].Countries[j]);
                        }
                    }
                }
                else
                {
                    ApplicationDbContext.Regions.AddRange(data[i]);
                }
            }
            LastReadedFile lastReaded = new LastReadedFile();
            lastReaded.LastRead = DateTime.Parse(fileDate);
            ApplicationDbContext.LastReadedFiles.Add(lastReaded);
            var result = await ApplicationDbContext.SaveChangesAsync();
        }
    }
}
