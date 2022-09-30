using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartController : ControllerBase
    {
        private readonly ILogger<PartController> _logger;
        private readonly IPartService _partService;

        public PartController(ILogger<PartController> logger,
            IPartService partService)
        {
            _logger = logger;
            _partService = partService;
        }

        // GET: api/<PartController>
        /// <summary> 
        /// Given a model ID, store ID and optional warehouse ID, reserve an item for a particular store (i.e., take it out of available inventory)
        /// Returns the reserved part back to the UI
        /// </summary> 
        /// <param name="modelId">Model Type of the Part</param>
        /// <param name="storeId">The store the part is at or is enroute too</param>
        /// <param name="warehouseId" optional>The warehouse where the part is or orginated from</param>
        /// <returns>Task<PartViewModel></returns> 
        [HttpGet("reserve/{modelId}/{storeId}/{warehouseId?}")]
        public async Task<PartViewModel> Reserve(int modelId, int storeId, int? warehouseId)
        {
            PartViewModel result = new();
            try {
                result = await _partService.ReservePartAsync(modelId, storeId, warehouseId);
            } catch (Exception ex) {
                _logger.LogError(ex, "Reserving part failed");
            }
            return result;
        }

        // GET: api/<PartController>
        /// <summary> 
        /// Request an email notification (given an email address) when an item arrives at a store
        /// </summary> 
        /// <param name="PartSubscription">The posted request object to create the part availability subscription</param>
        /// <returns>Task<IActionResult></returns> 
        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] PartSubscriptionRequestModel subscription)
        {
            try {
                if (subscription != null &&
                    subscription.PartId > 0 &&
                    subscription.StoreId > 0 &&
                    subscription.Email != null &&
                    Util.IsValidEmail(subscription.Email)) {
                        return await _partService.SubscribeAsync(subscription.PartId, subscription.StoreId, subscription.Email);
                }
                else { return BadRequest("Invalid Request"); }
            } catch (Exception ex) {
                _logger.LogError(ex, "Subscribe to part availability failed");
                return BadRequest();
            }
        }
    }
}