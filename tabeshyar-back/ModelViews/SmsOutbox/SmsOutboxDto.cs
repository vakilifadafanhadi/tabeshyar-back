namespace tabeshyar_back.ModelViews
{
    public class SmsOutboxDto
    {
        public int MessageId { get; set; }
        public string From { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string Receptions { get; set; } = default!;
        public bool Read { get; set; } = false;
    }
}
