using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasmShop.Data.Infrastructure;
using WasmShop.Data.Repositories;
using WasmShop.Model.Models;

namespace WasmShop.Service
{
    public interface IProductService
    {
        IEnumerable<Product> GetProductsByCategory(string category);

        Product GetProductByAlias(string alias);

        Product GetProductById(int id);

        IEnumerable<Size> GetProductSizesByProductId(int productId);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private ISizeRepository _sizeRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, ISizeRepository sizeRepository, UnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._productCategoryRepository = productCategoryRepository;
            this._sizeRepository = sizeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Product GetProductByAlias(string alias)
        {
            return _productRepository.GetSingleByCondition(p => p.Alias == alias);
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetSingleByCondition(p => p.ID == id);
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            var categoryId = _productCategoryRepository.GetSingleByCondition(pc => pc.Alias == category).ID;
            return _productRepository.GetMulti(x => x.CategoryID == categoryId);
        }

        public IEnumerable<Size> GetProductSizesByProductId(int productId)
        {
            return _sizeRepository.GetSizesByProductId(productId);
        }
    }
}