using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tabeshyar_back.Models
{
    public class SmsOutbox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public int MessageId { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string From { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string Receptions { get; set; } = default!;
    }
}
