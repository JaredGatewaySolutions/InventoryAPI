using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;

namespace InventoryAPI.Services
{
    public class ModelService : IModelService
    {
        private readonly ApplicationDbContext _context;

        public ModelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModelViewModel>> GetModelsByCategoryAsync(int categoryId)
        {
            return await _context.ModelType.Where(x => x.CategoryId == categoryId)
                .OrderByDescending(x => x.CategoryId)
                .ToListAsync();
        }
    }
}