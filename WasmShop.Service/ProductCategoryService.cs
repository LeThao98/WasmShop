using System.Collections.Generic;
using WasmShop.Data.Infrastructure;
using WasmShop.Data.Repositories;
using WasmShop.Model.Models;

namespace WasmShop.Service
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAll();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, UnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _productCategoryRepository.GetAll();
        }
    }
}