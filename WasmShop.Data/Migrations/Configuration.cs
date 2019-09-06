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
            SeedSizes(context);
            SeedProductSizes(context);
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
            productCategories.ForEach(p => context.ProductCategories.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();
        }

        private void SeedProducts(WasmShopDbContext context)
        {
            var products = new List<Product>
            {
                new Product{Name = "Áo Sơ Mi Nam kẻ sọc SM79", Alias = "ao-so-mi-nam-ke-soc-sm79",CategoryID=4 , Price = 79000},
                new Product{Name = "Áo sơ mi nam dài tay kẻ caro", Alias = "ao-so-mi-nam-dai-tay-ke-caro",CategoryID=4 , Price = 259000},
                new Product{Name = "Áo polo nam", Alias = "ao-polo-nam",CategoryID=4 , Price = 179000},
                new Product{Name = "Áo Polo nam kẻ", Alias = "ao-polo-nam-ke",CategoryID=4 , Price = 99000},
                new Product{Name = "Áo ba lỗ nam thể thao in to", Alias = "ao-ba-lo-nam-the-thao-in-to",CategoryID=4 , Price = 249000},
                new Product{Name = "Áo phông unisex người lớn", Alias = "ao-phong-unisex-nguoi-lon",CategoryID=4 , Price = 299000},
            };
            products.ForEach(p => context.Products.AddOrUpdate(s => s.Name, p));
            context.SaveChanges();
        }

        private void SeedSizes(WasmShopDbContext context)
        {
            var sizes = new List<Size>
            {
                new Size{ Name="S", Description="Small"},
                new Size{ Name="M", Description="Medium"},
                new Size{ Name="L", Description="Large"},
                new Size{ Name="XL", Description="Extra Large"},
            };
            sizes.ForEach(size => context.Sizes.AddOrUpdate(s => s.Name, size));
            context.SaveChanges();
        }

        private void SeedProductSizes(WasmShopDbContext context)
        {
            var productSizes = new List<ProductSize>
            {
                new ProductSize{ProductId = 1, SizeId = 1,Quantity = 3 },
                new ProductSize{ProductId = 1, SizeId = 2, Quantity = 5 },
            };
            productSizes.ForEach(ps => context.ProductSizes.AddOrUpdate(s => s.Quantity, ps));
            context.SaveChanges();
        }
    }
}