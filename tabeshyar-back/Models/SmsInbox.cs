namespace tabeshyar_back.Models
{
    public class SmsInbox : BaseEntity
    {
        public string From { get; set; } = default!;
        public string To { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string MessageId { get; set; } = default!;
    }
}
