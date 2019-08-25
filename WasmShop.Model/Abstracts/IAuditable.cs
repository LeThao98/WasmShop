using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmShop.Model.Abstracts
{
    public interface IAuditable
    {
        DateTime? CreatedTime { get; set; }
        string CreatedBy { get; set; }
        DateTime? ModifiedTime { get; set; }
        string ModifiedBy { get; set; }
    }
}