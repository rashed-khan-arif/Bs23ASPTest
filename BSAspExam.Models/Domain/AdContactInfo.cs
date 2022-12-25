namespace BSAspExam.Models.Domain
{
    public class AdContactInfo
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
