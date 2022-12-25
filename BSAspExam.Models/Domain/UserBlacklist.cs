using BSAspExam.Models.Identity;

namespace BSAspExam.Models.Domain
{
    public class UserBlacklist
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public bool Blocked { get; set; }

        public virtual Advertisement Advertisement { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
