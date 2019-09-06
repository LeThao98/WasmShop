using System;
using System.ComponentModel.DataAnnotations;

namespace WasmShop.Web.Models
{
    public class SizeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
        public string ModifiedBy { get; set; }
    }
}