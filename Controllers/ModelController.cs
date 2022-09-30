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
        private readonly IPartService _partService;

        public ModelController(
            ILogger<ModelController> logger,
            IModelService modelService,
            IPartService partService)
        {
            _logger = logger;
            _modelService = modelService;
            _partService = partService;
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
                var models = await _modelService.GetModelsByCategoryAsync(categoryId);
                var modelsList = models.ToList();

                for (var i = 0; i < modelsList.Count; i++)
                {
                    if (modelsList[i] != null)
                    {
                        var partsOfModelType = await _partService.GetByModelAsync(modelsList[i].Id);
                        var partsOfModelTypeList = partsOfModelType.ToList();

                        if (warehouseId > 0) {
                            modelsList[i].PartQuantity = partsOfModelTypeList.Where(p => p.WarehouseId == warehouseId).Count();
                        } else {
                            modelsList[i].PartQuantity = partsOfModelTypeList.Count;
                        }
                    }
                }

                result = modelsList;
            } catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
            }
            return result;
        }
    }
}
