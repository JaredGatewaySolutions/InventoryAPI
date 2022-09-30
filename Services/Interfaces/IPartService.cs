using InventoryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services.Interfaces
{
    public interface IPartService
    {
        // Reserves the part, then returns the reserved part to the UI
        // Sets the Parts availablility to false
        Task<PartViewModel> ReservePartAsync(int modelId, int storeId, int? warehouseId);

        // Get all parts of that model type
        Task<IEnumerable<PartViewModel>> GetByModelAsync(int modelId);

        // This will write the subscription to the DB where it will trigger the email later when the part is shipped
        Task<IActionResult> SubscribeAsync(int partId, int storeId, string email);
    }
}
