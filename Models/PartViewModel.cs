namespace InventoryAPI.Models
{
    public class PartViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int ModelId { get; set; }
        public int WarehouseId { get; set; }
        public int StoreId { get; set; }
        public int CategoryId { get; set; }
        public int CustomerId { get; set; }
        public bool IsAvailable { get; set; }
    }
}