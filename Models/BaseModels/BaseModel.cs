using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.BaseModels
{
    public class BaseModel : IAuditInfo
    {
        public BaseModel()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
