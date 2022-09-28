using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services
{
    public class PartService : IPartService
    {
        public Task<IEnumerable<PartViewModel>> GetByModel(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<PartViewModel> ReservePart(int modelId, int storeId, int? warehouseId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Subscribe(int partId, int storeId, string email)
        {
            throw new NotImplementedException();
        }
    }
}