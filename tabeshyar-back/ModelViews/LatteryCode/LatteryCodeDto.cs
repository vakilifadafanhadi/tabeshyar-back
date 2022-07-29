namespace tabeshyar_back.ModelViews
{
    public class LatteryCodeDto
    {
        public string? Owner { get; set; }
        public string ProductId { get; set; } = default!;
        public string? ResponceCode { get; set; }
        public string LatteryName { get; set; } = default!;
        public LatteryCodeDto()
        {
            Random random = new ();
            int res = random.Next();
            ResponceCode = res.ToString();
        }
    }
}
