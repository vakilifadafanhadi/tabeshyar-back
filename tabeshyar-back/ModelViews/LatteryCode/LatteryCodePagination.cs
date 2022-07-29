namespace tabeshyar_back.ModelViews
{
    public class LatteryCodePagination
    {
        public List<LatteryCodeDto> Data { get; set; }
        public int Count { get; set; }
        public LatteryCodePagination()
        {
            Data = new List<LatteryCodeDto>();
        }
    }
}
