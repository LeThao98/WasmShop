using WasmShop.Data.Infrastructure;
using WasmShop.Model.Models;

namespace WasmShop.Data.Repositories
{
    public class ProductTagRepository : RepositoryBase<ProductTag>
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}