using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WasmShop.Data.Repositories;
using WasmShop.Model.Models;
using WasmShop.Service;
using WasmShop.Web.Models;

namespace WasmShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductCategoryService _productCategoryService;

        public HomeController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            var productCategories = _productCategoryService.GetAll();
            var viewModel = Mapper.Map<IEnumerable<ProductCategoryViewModel>>(productCategories);
            return PartialView(viewModel);
        }
    }
}