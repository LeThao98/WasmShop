using WasmShop.Data.Infrastructure;
using WasmShop.Model.Models;

namespace WasmShop.Data.Repositories
{
    public class TagRepository : RepositoryBase<Tag>
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}