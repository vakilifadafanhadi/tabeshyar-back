using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tabeshyar_back.Repositories;
using tabeshyar_back.ModelViews;
namespace tabeshyar_back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LatteryCodesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public LatteryCodesController(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;
        [HttpPost(template:"[action]")]
        public async Task<IActionResult> Create(List<LatteryCodeDto> latteryCodes)
        {
            try
            {
                var newLatteryCodes = await _repositoryWrapper.LatteryCodeRepository.CreateRangeAsync(latteryCodes);
                await _repositoryWrapper.SaveAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet(template:"[action]/{pageNumber}/{take}")]
        public async Task<IActionResult> List([FromRoute] int pageNumber, [FromRoute] int take)
        {
            var result = new LatteryCodePagination
            {
                Data = await _repositoryWrapper.LatteryCodeRepository.GetPaginationAsync(pageNumber, take),
                Count = await _repositoryWrapper.LatteryCodeRepository.CountAsync()
            };
            return Ok(result);
        }
    }
}
