using MimeKit;

namespace InventoryAPI.Models
{
    public class EmailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public AttachmentCollection Attachments { get; set; }

        public EmailMessage(IEnumerable<string> to, string subject, string content, AttachmentCollection attachments)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x, x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }
    }
}
