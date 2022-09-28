using InventoryAPI.Models;

namespace InventoryAPI.Services.Interfaces
{
    public interface IModelService
    {
        Task<IEnumerable<ModelViewModel>> GetModelsByCategoryAsync(int categoryId, int? warehouseId);
    }
}
