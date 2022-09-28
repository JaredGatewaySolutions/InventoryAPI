namespace InventoryAPI.Models
{
    public class WarehouseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        /// <summary>
        /// Not stored in Database, derived from the count of parts stored in that warehose and of a provided model type.
        /// </summary>
        public int? PartQuantity { get; set; }
    }
}
