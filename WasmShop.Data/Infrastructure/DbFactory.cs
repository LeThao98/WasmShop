using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasmShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private WasmShopDbContext dbContext;

        public WasmShopDbContext Init()
        {
            return dbContext ?? (dbContext = new WasmShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}