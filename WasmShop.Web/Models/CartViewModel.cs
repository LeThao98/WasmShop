using System.Collections.Generic;
using WasmShop.Service;

namespace WasmShop.Web.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            Cart = new Cart();
        }

        public Cart Cart { get; set; }
        public decimal Total { get; set; }
    }
}