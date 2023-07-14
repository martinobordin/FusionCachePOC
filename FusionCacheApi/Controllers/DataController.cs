using FusionCacheApi.Services;
using FusionCacheShared;
using Microsoft.AspNetCore.Mvc;

namespace FusionCacheApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpGet]
        public async Task<CacheData?> GetDataAsync(CancellationToken cancellationToken = default)
        {
            return await dataService.GetDataAsync(cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult> SetData(CacheData cacheData, CancellationToken cancellationToken = default)
        {
            await dataService.SetDataAsync(cacheData, cancellationToken);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteData(CancellationToken cancellationToken = default)
        {
            await dataService.DeleteDataAsync(cancellationToken);
            return Ok();
        }
    }
}