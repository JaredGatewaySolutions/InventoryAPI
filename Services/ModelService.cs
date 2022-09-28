using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;

namespace InventoryAPI.Services
{
    public class ModelService : IModelService
    {
        public Task<IEnumerable<ModelViewModel>> GetModelsByCategoryAsync(int categoryId, int? warehouseId)
        {
            throw new NotImplementedException();
        }
    }
}