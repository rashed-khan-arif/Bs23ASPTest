namespace BSAspExam.Models.Domain
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ImageId { get; set; }
        public bool Active { get; set; }


        public virtual Product Product { get; set; }
        public virtual Image Image { get; set; }
    }
}
