using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LastReadedFile : BaseModel
    {
        public LastReadedFile(): base()
        {
        }
        public DateTime LastRead { get; set; }
    }
}
