using BSAspExam.Models.Common;

namespace BSAspExam.Models.Domain
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<AdImage> AdImages { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
