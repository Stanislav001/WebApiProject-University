using Services.ViewModels;
using System.Collections.Generic;

namespace Services.ModelServices.Interfaces
{
    public interface IRegionService
    {
        public List<RegionViewModel> GetAllRegions();
        public CountryViewModel SearchRegionByName(string name);
        public List<SalesViewModel> TopSalesByTotalProfit();
    }
}
