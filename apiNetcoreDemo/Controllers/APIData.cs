using apiNetcoreDemo.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiNetcoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIData : ControllerBase
    {
        private readonly MyDbContext _dbcntxt;

        public APIData(MyDbContext myWorldDbContext)
        {
            _dbcntxt = myWorldDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var cakes = await _dbcntxt.Cake.ToListAsync();
            return Ok(cakes);
        }
    }
}
