﻿using System.ComponentModel.DataAnnotations;

namespace tabeshyar_back.Models
{
    public class SmsOutbox:BaseEntity
    {
        [Required]
        public int MessageId { get; set; }
        public string From { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string Receptions { get; set; } = default!;
        public bool Read { get; set; } = false;
    }
}
