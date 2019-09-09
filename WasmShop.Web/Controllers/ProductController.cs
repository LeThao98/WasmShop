using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasmShop.Service;
using WasmShop.Web.Infrastructure;
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
        public ActionResult List(int page = 1)
        {
            var pageSize = int.Parse(Common.ConfigHelper.GetByKey("pageSize"));
            var maxPage = int.Parse(Common.ConfigHelper.GetByKey("maxPage"));
            var category = RouteData.Values["category"].ToString();
            var productList = _productService.GetListProductByCategoryIdPaging(category, page, pageSize, null, out int totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var productListViewModel = Mapper.Map<IEnumerable<ProductViewModel>>(productList);
            var viewModel = new PaginationSet<ProductViewModel>()
            {
                Page = page,
                Count = pageSize,
                TotalPages = totalPage,
                TotalCount = totalPage,
                MaxPage = maxPage,
                Items = productListViewModel
            };
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