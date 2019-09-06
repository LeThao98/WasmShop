using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasmShop.Service;
using WasmShop.Web.Models;

namespace WasmShop.Web.Controllers
{
    public class CartController : Controller
    {
        private ICartService _cartService;
        private IProductService _productService;

        public CartController(IProductService productService, ICartService cartService)
        {
            this._productService = productService;
            this._cartService = cartService;
        }

        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult SummaryCart(CartViewModel cartViewModel)
        {
            return PartialView(cartViewModel);
        }

        public RedirectToRouteResult AddToCart(CartViewModel cartViewModel, int productId, int sizeId)
        {
            var product = _productService.GetProductById(productId);
            cartViewModel.Total += product.Price;
            _cartService.AddItem(cartViewModel.Cart, product, sizeId, 1);
            Session["Cart"] = cartViewModel;
            return RedirectToActionPermanent("Detail", "Product", new { alias = product.Alias });
        }

        public ActionResult CheckOut(CartViewModel cartViewModel)
        {
            return View(cartViewModel);
        }

        //public JsonResult AddToCart(CartViewModel cartViewModel, int productId, int sizeId)
        //{
        //    if (Session["Cart"] == null) Session["Cart"] = new List<CartLine>();
        //    var product = _productService.GetProductById(productId);
        //    cartViewModel.Total += product.Price;
        //    _cartService.AddItem(cartViewModel.Cart, product, sizeId, 1);
        //    Session["Cart"] = cartViewModel;
        //    return Json(new { CartViewModel = cartViewModel });
        //}
    }
}