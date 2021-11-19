using Models.BaseModels;
using System;
using System.Collections.Generic;

namespace Models
{
    public class Region : BaseModel
    {
        public Region() :base()
        {
        }
        public string RegionName { get; set; }
        public List<Country> Countries { get; set; }
    }
}
