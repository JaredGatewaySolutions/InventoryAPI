using InventoryAPI.Models;
using InventoryAPI.Services.Interfaces;

namespace InventoryAPI.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly ApplicationDbContext _context;
        private readonly PartService _partService;


        public WarehouseService(ApplicationDbContext context, PartService partService)
        {
            _context = context;
            _partService = partService;
        }

        /// <summary> 
        /// Lists the quantity of items per warehouse given a particular model ID. 
        /// </summary> 
        /// <param name="modelId">Id of the model being searched for</param>
        /// <returns>Task<IEnumerable<WarehouseViewModel>></returns> 
        public async Task<IEnumerable<WarehouseViewModel>> GetByModelIdAsync(int modelId)
        {
            var warehouses = await GetAllAsync();
            var warehouseList = warehouses.ToList();

            var parts = await _partService.GetByModelAsync(modelId);
            var partsList = parts.ToList();

            for (var i = 0; i < warehouseList.Count; i++)
            {
                if (warehouseList[i] != null)
                {
                    warehouseList[i].PartQuantity = partsList.Where(p => p.WarehouseId == warehouseList[i].Id).Count();
                }
            }
            
            return warehouseList;
        }

        /// <summary> 
        /// Lists all warehouses. 
        /// </summary> 
        /// <param name="modelId">Id of the model being searched for</param>
        /// <returns>Task<IEnumerable<WarehouseViewModel>></returns> 
        public async Task<IEnumerable<WarehouseViewModel>> GetAllAsync()
        {
            return await _context.Warehouse
                .OrderByDescending(x => x.Address)
                .ToListAsync();
        }
    }
}