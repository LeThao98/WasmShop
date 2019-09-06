using System.Collections.Generic;
using WasmShop.Model.Abstracts;

namespace WasmShop.Web.Models
{
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int CategoryID { get; set; }
        public string Image { get; set; }

        public string MoreImages { get; set; }

        public decimal Price { get; set; }
        public decimal? PromotionPrice { get; set; }

        public decimal OriginalPrice { get; set; }

        public string Description { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        public string Tags { get; set; }
        public virtual ProductCategoryViewModel ProductCategory { get; set; }

        public virtual IEnumerable<ProductTagViewModel> ProductTags { get; set; }
    }
}