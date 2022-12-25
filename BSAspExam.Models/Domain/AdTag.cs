namespace BSAspExam.Models.Domain
{
    public class AdTag
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int TagId { get; set; }
        public bool Active { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }
}
