namespace InventoryAPI.Models
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        /// <summary>
        /// Not stored in Database, derived from part count of that model type
        /// </summary>
        public int? PartQuantity { get; set; }
        public int CategoryId { get; set; }
    }
}
