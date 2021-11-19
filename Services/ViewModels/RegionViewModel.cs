using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class RegionViewModel
    {
        public string RegionName { get; set; }
        public List<CountryViewModel> Countries { get; set; }
        public List<SalesViewModel> Sales { get; set; }
    }
}
