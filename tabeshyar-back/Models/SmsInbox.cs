using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tabeshyar_back.Models
{
    public class SmsInbox
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string From { get; set; } = default!;
        public string To { get; set; } = default!;
        public string Message { get; set; } = default!;
        public bool Read { get; set; } = false;
    }
}
