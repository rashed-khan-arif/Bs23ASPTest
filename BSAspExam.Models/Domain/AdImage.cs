namespace BSAspExam.Models.Domain
{
    public class AdImage
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int ImageId { get; set; }
        public bool Active { get; set; }

        public virtual Advertisement Advertisement { get; set; }
        public virtual Image Image { get; set; }
    }
}
