using InventoryAPI.Models;

namespace InventoryAPI.Services.Interfaces
{
    public interface IWarehouseService
    {
        // Get the quantity of parts for that model contained in each warehouse
        Task<IEnumerable<WarehouseViewModel>> GetByModelId(int modelId);
    }
}
