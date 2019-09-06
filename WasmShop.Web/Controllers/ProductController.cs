using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasmShop.Service;
using WasmShop.Web.Models;

namespace WasmShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        // GET: Product
        public ActionResult List()
        {
            var category = RouteData.Values["category"].ToString();
            var productList = _productService.GetProductsByCategory(category);
            var viewModel = Mapper.Map<IEnumerable<ProductViewModel>>(productList);
            return View(viewModel);
        }

        public ActionResult Detail()
        {
            var alias = RouteData.Values["alias"].ToString();
            var product = _productService.GetProductByAlias(alias);
            var productSizes = _productService.GetProductSizesByProductId(product.ID);
            ProductViewModel productviewModel = Mapper.Map<ProductViewModel>(product);
            IEnumerable<SizeViewModel> sizeViewModel = Mapper.Map<IEnumerable<SizeViewModel>>(productSizes);
            var viewModel = new ProductDetailViewModel()
            {
                Details = productviewModel,
                Sizes = sizeViewModel
            };
            return View(viewModel);
        }
    }
}