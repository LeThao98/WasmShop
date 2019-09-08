using System.Collections.Generic;
using System.Linq;
using WasmShop.Data.Repositories;
using WasmShop.Model.Models;

namespace WasmShop.Service
{
    public interface ICartService
    {
        void AddItem(Cart cart, Product product, int sizeId, int quantity);

        void RemoveItem(Cart cart, int productId, int sizeId);

        void Clear(Cart cart);
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

        public void Clear(Cart cart)
        {
            cart.cartLines.Clear();
        }

        public void RemoveItem(Cart cart, int productId, int sizeId)
        {
            CartLine line = cart.cartLines.Where(cl => cl.Product.ID == productId && cl.Size.Id == sizeId).FirstOrDefault();
            cart.cartLines.Remove(line);
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