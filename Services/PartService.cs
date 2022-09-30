using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PartViewModel>> GetByModelAsync(int modelId)
        {
            return await _context.Part.Where(x => x.ModelId == modelId)
                .OrderByDescending(x => x.ModelId)
                .ToListAsync();
        }

        public async Task<PartViewModel> ReservePartAsync(int modelId, int storeId, int? warehouseId)
        {
            throw new NotImplementedException();
        }

        public async Task<IActionResult> SubscribeAsync(int partId, int storeId, string email)
        {
            throw new NotImplementedException();
        }
    }
}