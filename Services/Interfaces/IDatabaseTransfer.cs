using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDatabaseTransfer
    {
        public Task TransferAsync(List<RegionViewModel> regions, string fileDate);
    }
}
