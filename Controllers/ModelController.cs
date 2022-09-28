using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ILogger<ModelController> _logger;
        private readonly IModelService _modelService;

        public ModelController(
            ILogger<ModelController> logger,
            IModelService modelService)
        {
            _logger = logger;
            _modelService = modelService;
        }

        // GET: api/<ModelController>
        /// <summary> 
        /// List the model name and quantity given an optional warehouse identifier of a specified part category. 
        /// </summary> 
        /// <param name="categoryId">Id of the category of models being listed</param>
        /// <param optional name="warehouseId">If provided, filter results by warehouse</param>
        /// <returns>Task<IEnumerable<ModelViewModel>></returns> 
        [HttpGet("list/{categoryId}/{warehouseId?}")]
        public async Task<IEnumerable<ModelViewModel>> GetByCategory(int categoryId, int? warehouseId)
        {
            IEnumerable<ModelViewModel> result = Enumerable.Empty<ModelViewModel>();
            try {
                result = await _modelService.GetModelsByCategoryAsync(categoryId, warehouseId);
            } catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
            }
            return result;
        }
    }
}
