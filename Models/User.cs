using Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
