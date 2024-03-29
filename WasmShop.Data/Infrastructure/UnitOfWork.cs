﻿namespace WasmShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private WasmShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public WasmShopDbContext DbContext
        {
            get => dbContext ?? (dbContext = dbFactory.Init());
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}