using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {

        private readonly ILogger<WarehouseController> _logger;
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(ILogger<WarehouseController> logger,
            IWarehouseService warehouseService)
        {
            _logger = logger;
            _warehouseService = warehouseService;
        }

        // GET: api/<WarehouseController>
        /// <summary> 
        /// Lists the quantity of items per warehouse given a particular model ID. 
        /// </summary> 
        /// <param name="modelId">Id of the model being searched for</param>
        /// <returns>Task<IEnumerable<WarehouseViewModel>></returns> 
        [HttpGet("list/{modelId}")]
        public async Task<IEnumerable<WarehouseViewModel>> GetByModelId(int modelId)
        {
            IEnumerable<WarehouseViewModel> result = Enumerable.Empty<WarehouseViewModel>();
            try {
                result = await _warehouseService.GetByModelId(modelId);
            } catch (Exception ex) {
                _logger.LogError(ex.StackTrace);
            }
            return result;
        }
    }
}
