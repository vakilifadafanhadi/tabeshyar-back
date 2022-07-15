using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tabeshyar_back.Models
{
    public class LatteryCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Status { get; set; } = 0;
        public string? Owner { get; set; }
        public string ProductId { get; set; } = default!;
        public string? ResponceCode { get; set; }
        public LatteryCode()
        {
            Random random = new();
            ResponceCode = random.Next().ToString();
        }
    }
}
