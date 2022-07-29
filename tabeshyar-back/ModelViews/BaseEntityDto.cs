namespace tabeshyar_back.ModelViews
{
    public class BaseEntityDto
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        public int Status { get; set; }
    }
}
