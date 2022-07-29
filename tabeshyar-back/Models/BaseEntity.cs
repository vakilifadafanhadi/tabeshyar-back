using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tabeshyar_back.Models
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public int Status { get; set; }
        public BaseEntity()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
            Status = 0;
        }

    }
}
