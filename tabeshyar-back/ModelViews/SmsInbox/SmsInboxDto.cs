namespace tabeshyar_back.ModelViews
{
    public class SmsInboxDto:BaseEntityDto
    {
        public string From { get; set; } = default!;
        public string To { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string MessageId { get; set; } = default!;
    }
}
