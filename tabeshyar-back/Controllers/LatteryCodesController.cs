using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tabeshyar_back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LatteryCodesController : ControllerBase
    {
        private readonly TabeshyarDb _db;
        public LatteryCodesController(TabeshyarDb db) => _db = db;
        [HttpPost(template:"[action]")]
        public async Task<IActionResult> Create(List<Models.LatteryCode> latteryCodes)
        {
            try
            {
                await _db.LatteryCodes.AddRangeAsync(latteryCodes);
                _db.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet(template:"[action]")]
        public async Task<IActionResult> List()
        {
            var result = await _db.LatteryCodes.ToListAsync();
            return Ok(result);
        }
    }
}
