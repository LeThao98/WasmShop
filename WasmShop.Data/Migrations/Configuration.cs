using WasmShop.Data;

namespace WasmShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WasmShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WasmShop.Data.WasmShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WasmShopDbContext context)
        {
            SeedProductCategories(context);
            SeedProducts(context);
        }

        private void SeedProductCategories(WasmShopDbContext context)
        {
            var productCategories = new List<ProductCategory>
            {
                new ProductCategory{Name="Men",Alias="men"},
                new ProductCategory{Name="Women",Alias="women"},
                new ProductCategory{Name="Kids",Alias="kids"},
                new ProductCategory{Name="Men Clothing",Alias="men-clothing",ParentID=1},
                new ProductCategory{Name="Men Footwear",Alias="men-footwear",ParentID=1},
                new ProductCategory{Name="Men Watch",Alias="men-watch",ParentID=1}
            };
            productCategories.ForEach(p => context.ProductCategory.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();
        }

        private void SeedProducts(WasmShopDbContext context)
        {
        }
    }
}