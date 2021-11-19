﻿using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFilesReader
    {
        public IEnumerable<TransferViewModel> FileReader(string dir);
    }
}