using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;

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

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual ICollection<AdImage> AdImages { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
