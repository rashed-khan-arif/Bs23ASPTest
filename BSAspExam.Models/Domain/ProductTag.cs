namespace BSAspExam.Models.Domain
{
    public class ProductTag
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public bool Active { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Product Product { get; set; }
    }
}
