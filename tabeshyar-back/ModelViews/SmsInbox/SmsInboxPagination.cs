namespace tabeshyar_back.ModelViews
{
    public class SmsInboxPagination
    {
        public List<SmsInboxDto> Data { get; set; }
        public int Count { get; set; }
        public SmsInboxPagination()
        {
            Data = new List<SmsInboxDto>();
        }
    }
}
