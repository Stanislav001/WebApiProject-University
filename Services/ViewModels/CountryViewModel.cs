using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class CountryViewModel
    {
        public string CountryName { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public List<SalesViewModel> Sales { get; set; }
    }
}
