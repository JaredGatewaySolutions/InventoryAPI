namespace InventoryAPI.Models
{
    public class PartSubscriptionRequestModel
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int PartId { get; set; }
        public string? Email { get; set; }
    }
}
