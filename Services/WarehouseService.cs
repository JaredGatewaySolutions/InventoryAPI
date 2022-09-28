using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;

namespace InventoryAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        public Task<IEnumerable<WarehouseViewModel>> GetByModelId(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}