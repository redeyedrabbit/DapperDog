using DapperDog.Data;
using DapperDog.Models.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Services
{
    public class BrandService
    {
        private readonly Guid _userId;

        public BrandService(Guid userId)
        {
            _userId = userId;
        }

        public BrandService() { }

        public BrandDetail GetBrandDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var brand = ctx.Brands.Single(m => m.BrandId == id);
                return new BrandDetail
                {
                    BrandId = brand.BrandId,
                    Name = brand.Name
                };
            }
        }

        public bool CreateBrand(BrandCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newBrand = new Brand()
                {
                    Name = model.Name
                };

                ctx.Brands.Add(newBrand);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BrandListItem> GetBrandList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Brands.Select(m => new BrandListItem
                {
                    BrandId = m.BrandId,
                    Name = m.Name
                });

                return query.ToArray();
            }

        }

        public IEnumerable<Brand> GetBrands()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Brands.ToList();
                
            }
        }

        public bool UpdateBrand(BrandEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var brand = ctx.Brands.Single(m => m.BrandId == model.BrandId);
                brand.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteBrand(int brandId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Brands.Any(m => m.BrandId == brandId))
                    return false;

                var model =
                    ctx
                    .Brands
                    .Single(m => m.BrandId == brandId);

                ctx.Brands.Remove(model);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
