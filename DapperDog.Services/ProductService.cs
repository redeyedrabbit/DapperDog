using DapperDog.Data;
using DapperDog.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public ProductDetail GetProductDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product = ctx.Products.Single(m => m.ProductId == id);
                return new ProductDetail
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    BrandId = product.BrandId,
                    Size = product.Size,
                    Price = product.Price,
                    InventoryCount = product.InventoryCount

                };
            }
        }

        public bool CreateProduct(ProductCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newProduct = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    BrandId = model.BrandId,
                    Size = model.Size,
                    Price = model.Price,
                    InventoryCount = model.InventoryCount


                };

                ctx.Products.Add(newProduct);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProductList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Products.Select(m => new ProductListItem
                {
                    ProductId = m.ProductId,
                    Name = m.Name,
                    CategoryId = m.CategoryId,
                    Price = m.Price,
                    InventoryCount = m.InventoryCount
                });

                return query.ToArray();
            }

        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var product = ctx.Products.Single(m => m.ProductId == model.ProductId);
                product.Name = model.Name;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                product.BrandId = model.BrandId;
                product.Size = model.Size;
                product.Price = model.Price;
                product.InventoryCount = model.InventoryCount;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                //if (!ctx.Products.Any(m => m.ProductId == productId))
                //    return false;
                //var model =
                //    ctx
                //    .Products
                //    .Single(m => m.ProductId == productId);

                //ctx.Products.Remove(model);

                //return ctx.SaveChanges() == 1;

                var entity = ctx
                    .Products
                    .Single(e => e.ProductId == productId);
                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
