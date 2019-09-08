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

        public PartialViewResult SummaryCart(CartViewModel cartViewModel)
        {
            return PartialView(cartViewModel);
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(CartViewModel cartViewModel, int productId, int sizeId)
        {
            var product = _productService.GetProductById(productId);
            cartViewModel.Total += product.Price;
            _cartService.AddItem(cartViewModel.Cart, product, sizeId, 1);
            return RedirectToActionPermanent("Detail", "Product", new { alias = product.Alias });
        }

        public ActionResult Index(CartViewModel cartViewModel)
        {
            return View(cartViewModel);
        }

        [HttpPost]
        public ActionResult CheckOut(CartViewModel cartViewModel)
        {
            cartViewModel.Total = 0;
            _cartService.Clear(cartViewModel.Cart);
            TempData["Success"] = "Cảm ơn bạn đã đặt hàng tại WasmShop!!!";
            return RedirectToAction("Index", "Home");
        }

        public RedirectResult DeleteItem(CartViewModel cartViewModel, int productId, int sizeId, string returnUrl)
        {
            var product = _productService.GetProductById(productId);
            decimal price = product.Price;
            _cartService.RemoveItem(cartViewModel.Cart, productId, sizeId);
            cartViewModel.Total -= price;
            return Redirect(returnUrl);
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