using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WasmShop.Model.Models
{
    [Table("ProductSizes")]
    public class ProductSize
    {
        [Key]
        [Column(Order = 2)]
        public int SizeId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Size Size { get; set; }
    }
}