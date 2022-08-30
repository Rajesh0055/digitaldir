using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Interface;
using Microsoft.AspNetCore.Mvc;

namespace apiNetcoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : Controller
    {
        private ILogger _logger;
        private IServiceManager _serviceManager;
        public ServicesController(ILogger<ServicesController> logger, IServiceManager serviceManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;

        }


        /// <summary>
        /// controller method to add new service list
        /// </summary>
        /// <param name="serviceData">service information object</param>
        /// <returns>service data object</returns>
        [HttpPost("add-new-business")]
        public ActionResult<ServiceMaster> AddNewService(ServiceMaster serviceData)
        {
            try
            {
                _serviceManager.AddNewService(serviceData);
                return serviceData;
            }
            catch(Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                throw;
            }
        }



        /// <summary>
        /// to get all exsits services 
        /// </summary>
        /// <returns>list of service</returns>
        [HttpGet("all-Services")]
        public ActionResult<List<ServiceMaster>> GetAllServices()
        {
            try
            {
                return _serviceManager.GetServiceLists();
            }
            catch
            { 
                throw;
            }
        }

    }
}
