namespace BSAspExam.Models.Domain
{
    public class ProductBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
