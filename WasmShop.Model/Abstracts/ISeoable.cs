﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmShop.Model.Abstracts
{
    public interface ISeoable
    {
        string MetaKeyWord { get; set; }
        string MetaDescription { get; set; }
    }
}