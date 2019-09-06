using System.Collections.Generic;

namespace WasmShop.Web.Models
{
    public class ProductSizeViewModel
    {
        public int SizeId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual ProductViewModel Product { get; set; }
        public virtual IEnumerable<SizeViewModel> Sizes { get; set; }
    }
}