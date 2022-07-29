using tabeshyar_back.Models;

namespace tabeshyar_back.ModelViews
{
    public class SmsOutboxPagination
    {
        public List<SmsOutboxDto> Data { get; set; }
        public int Count { get; set; }
        public SmsOutboxPagination()
        {
            Data = new List<SmsOutboxDto>();
        }
    }
}
