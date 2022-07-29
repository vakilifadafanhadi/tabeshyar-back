namespace tabeshyar_back.Models
{
    public class LatteryCode : BaseEntity
    {
        public string? Owner { get; set; }
        public string LatteryName { get; set; } = default!;
        public string ProductId { get; set; } = default!;
        public string? ResponceCode { get; set; }
    }
}
