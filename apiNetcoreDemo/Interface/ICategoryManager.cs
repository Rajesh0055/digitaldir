using apiNetcoreDemo.Data.Entity;

namespace apiNetcoreDemo.Interface
{
    /// <summary>
    /// manager for category
    /// </summary>
    public interface ICategoryManager
    {
        public CategoryMaster AddCategory(CategoryMaster category);
    }
}
