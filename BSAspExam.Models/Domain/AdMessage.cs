using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;

namespace BSAspExam.Models.Domain
{
    public class AdMessage : IEntity
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual Advertisement Advertisement { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
    }
}
