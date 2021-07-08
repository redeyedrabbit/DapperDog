using DapperDog.Data;
using DapperDog.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public CategoryDetail GetCategoryDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Single(m => m.CategoryId == id);
                return new CategoryDetail
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name
                };
            }
        }

        public bool CreateCategory(CategoryCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newCategory = new Category()
                {
                    Name = model.Name
                };

                ctx.Categories.Add(newCategory);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategoryList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Categories.Select(m => new CategoryListItem
                {
                    CategoryId = m.CategoryId,
                    Name = m.Name
                });

                return query.ToArray();
            }

        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var category = ctx.Categories.Single(m => m.CategoryId == model.CategoryId);
                category.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Categories.Any(m => m.CategoryId == categoryId))
                    return false;

                var model =
                    ctx
                    .Categories
                    .Single(m => m.CategoryId == categoryId);

                ctx.Categories.Remove(model);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
