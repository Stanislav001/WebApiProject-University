using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IAuditInfo
    {
        public DateTime CreatedAt { get; set; }
    }
}
