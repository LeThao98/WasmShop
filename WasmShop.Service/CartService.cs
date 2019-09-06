using System.Collections.Generic;
using System.Linq;
using WasmShop.Data.Repositories;
using WasmShop.Model.Models;

namespace WasmShop.Service
{
    public interface ICartService
    {
        void AddItem(Cart cart, Product product, int sizeId, int quantity);
    }

    public class CartService : ICartService
    {
        private readonly ISizeRepository _sizeRepository;

        public CartService(ISizeRepository sizeRepository)
        {
            this._sizeRepository = sizeRepository;
        }

        public void AddItem(Cart cart, Product product, int sizeId, int quantity)
        {
            CartLine line = cart.cartLines
           .Where(p => p.Product.ID == product.ID && p.Size.Id == sizeId)
           .FirstOrDefault();
            var size = _sizeRepository.GetSingleById(sizeId);
            if (line == null)
            {
                cart.cartLines.Add(new CartLine
                {
                    Product = product,
                    Size = size,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }

        public Size Size { get; set; }

        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartLine> cartLines = new List<CartLine>();
    }
}