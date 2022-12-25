using BSAspExam.Models.Common; 

namespace BSAspExam.Models.Domain
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ProductBrand Brand { get; set; }
        public virtual Advertisement Advertisement { get; set; }
        public virtual ProductCategory Category { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductTag> Tags { get; set; }

    }
}
