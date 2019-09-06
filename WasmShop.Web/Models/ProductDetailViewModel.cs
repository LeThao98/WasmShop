using System.Collections.Generic;

namespace WasmShop.Web.Models
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Details { get; set; }
        public IEnumerable<SizeViewModel> Sizes { get; set; }
    }
}