using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WasmShop.Data.Infrastructure;
using WasmShop.Model.Models;

namespace WasmShop.Data.Repositories
{
    public interface ISizeRepository : IRepository<Size>
    {
        IEnumerable<Size> GetSizesByProductId(int productId);
    }

    public class SizeRepository : RepositoryBase<Size>, ISizeRepository
    {
        public SizeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Size> GetSizesByProductId(int productId)
        {
            return DbContext.Sizes
                .Join(DbContext.ProductSizes, s => s.Id, ps => ps.SizeId, (s, ps) => new { ProductId = ps.ProductId, Sizes = s })
                .Where(r => r.ProductId == productId).Select(r => r.Sizes);
        }
    }
}