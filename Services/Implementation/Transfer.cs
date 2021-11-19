using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class Transfer : ITransfer
    {
        public List<RegionViewModel> ModelHandler(List<TransferViewModel> models)
        {
            List<RegionViewModel> regions = new List<RegionViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                var region = regions.FirstOrDefault(x => x.RegionName.ToUpper() == models[i].RegionName.ToUpper());
                // Region check
                if (region == null)
                {
                    regions.Add(new RegionViewModel()
                    {
                        RegionName = models[i].RegionName,
                        Countries = new List<CountryViewModel>() { new CountryViewModel()
                        {
                            CountryName = models[i].CountryName,
                            Orders = new List<OrderViewModel>(){new OrderViewModel()
                            {
                                ItemType = models[i].ItemType,
                                OrderDate = models[i].OrderDate,
                                OrderId = models[i].OrderId,
                                OrderPrioriy = models[i].OrderPrioriy,
                                SalesChannel = models[i].SalesChannel,

                                Sales = new List<SalesViewModel>(){new SalesViewModel()
                                {
                                    ShipDate = models[i].ShipDate,
                                    UnitsSold = models[i].UnitsSold,
                                    UnitPrice = models[i].UnitPrice,
                                    UnitCost = models[i].UnitCost,
                                    TotalRevenue = models[i].TotalRevenue,
                                    TotalCost = models[i].TotalCost,
                                    TotalProfit = models[i].TotalProfit
                                }
                                }
                            }
                            }
                        }
                        }
                    }); ;
                }
                else
                {
                    var country = region.Countries.FirstOrDefault(x => x.CountryName.ToUpper() == models[i].CountryName.ToUpper());

                    if (country == null)
                    {
                        region.Countries.Add(new CountryViewModel()
                        {
                            CountryName = models[i].CountryName,
                            Orders = new List<OrderViewModel>() { new OrderViewModel()
                            {
                                ItemType = models[i].ItemType,
                                OrderDate = models[i].OrderDate,
                                OrderId = models[i].OrderId,
                                OrderPrioriy = models[i].OrderPrioriy,
                                SalesChannel = models[i].SalesChannel,
                                TotalProfit = models[i].TotalProfit,
                                UnitCost = models[i].UnitCost,
                                UnitPrice = models[i].UnitPrice,
                                UnitsSold = models[i].UnitsSold,
                                Sales = new List<SalesViewModel>() {new SalesViewModel()
                                {
                                    ShipDate = models[i].ShipDate,
                                    UnitsSold = models[i].UnitsSold,
                                    UnitPrice = models[i].UnitPrice,
                                    UnitCost = models[i].UnitCost,
                                    TotalRevenue = models[i].TotalRevenue,
                                    TotalCost = models[i].TotalCost,
                                    TotalProfit = models[i].TotalProfit
                                }
                                }
                            }
                            }
                        });
                    }
                    else
                    {
                        country.Orders.Add(new OrderViewModel()
                        {
                            ItemType = models[i].ItemType,
                            OrderDate = models[i].OrderDate,
                            OrderId = models[i].OrderId,
                            OrderPrioriy = models[i].OrderPrioriy,
                            SalesChannel = models[i].SalesChannel,
                            Sales = new List<SalesViewModel>() {new SalesViewModel()
                                {
                                    ShipDate = models[i].ShipDate,
                                    UnitsSold = models[i].UnitsSold,
                                    UnitPrice = models[i].UnitPrice,
                                    UnitCost = models[i].UnitCost,
                                    TotalRevenue = models[i].TotalRevenue,
                                    TotalCost = models[i].TotalCost,
                                    TotalProfit = models[i].TotalProfit
                                }
                            }
                        });
                    }
                }
            }
            return regions;
        }
    }
}
