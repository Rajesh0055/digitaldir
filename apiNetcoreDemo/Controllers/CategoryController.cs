using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace apiNetcoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private ILogger _logger;
        private ICategoryManager _categoryManager;
        public CategoryController(ILogger<ServicesController> logger, ICategoryManager categoryManager)
        {
            _logger = logger;
            _categoryManager = categoryManager;

        }


        [HttpPost("add-new-category")]
        public ActionResult<CategoryMaster> AddNewService(CategoryMaster categoryObj)
        {
            try
            {
                _categoryManager.AddCategory(categoryObj);
                return categoryObj;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }

    }
}
