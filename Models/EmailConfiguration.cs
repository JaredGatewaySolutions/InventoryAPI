namespace InventoryAPI.Models
{
    public class EmailConfiguration
    {
        public string? From { get; set; }
        public string? Name { get; set; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? AppPassword { get; set; }
        public string? Password { get; set; }
    }
}
