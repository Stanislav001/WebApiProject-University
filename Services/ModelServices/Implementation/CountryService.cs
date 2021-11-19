using AutoMapper;
using Date;
using Models;
using Services.ModelServices.Interfaces;
using Services.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Services.ModelServices.Implementation
{
    public class CountryService : ICountryService
    {
        public ApplicationDbContext ApplicationDbContext { get; }
        public IMapper Mapper { get; }
        public CountryService(ApplicationDbContext context, IMapper mapper)
        {
            ApplicationDbContext = context;
            Mapper = mapper;
        }

        // Get all countries
        public List<CountryViewModel> GetAllCountries()
        {
            List<Country> country = ApplicationDbContext.Countries
                                  .Select(x => new Country()
                                  {
                                      CountryName = x.CountryName
                                  }).ToList();

            List<CountryViewModel> countries = Mapper.Map<List<CountryViewModel>>(country);
            return countries;
        }

        // Get country by region
        public List<CountryViewModel> GetCountryByRegion(string id)
        {
            var country = ApplicationDbContext.Countries.Where(x => x.Id == id).ToList();
            var result = Mapper.Map<List<CountryViewModel>>(country);

            return result;
        }

        // Get total orders by country
        public Dictionary<string, int> GetTotalOrdersByCountry()
        {
            var result = ApplicationDbContext.Orders
                         .GroupBy(x => x.CountryId, (c, o) => new { Country = c, TotalOrders = o.Count() })
                         .ToDictionary(a => a.Country, b => b.TotalOrders);

            return result;
        }

        // Get country by name
        public CountryViewModel SearchCountryByName(string name)
        {
            var country = ApplicationDbContext.Countries
                          .FirstOrDefault(x => x.CountryName.ToUpper() == name.ToUpper());

            var result = Mapper.Map<CountryViewModel>(country);
            return result;
        }
    }
}
