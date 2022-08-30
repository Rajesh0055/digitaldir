using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;

namespace apiNetcoreDemo.Services
{
    public class CategoryService : ICategoryManager
    {

        private readonly MyDbContext myDbContext;

        public CategoryService(MyDbContext dbContext)
        {
            myDbContext = dbContext;
        }
        public CategoryMaster AddCategory(CategoryMaster category)
        {
            myDbContext.CategoryMaster.Add(category);  // pass the table object 
            myDbContext.SaveChanges();
            return category;

        }
    }
}
