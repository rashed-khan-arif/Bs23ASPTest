using BSAspExam.Models.Common;

namespace BSAspExam.Models.Domain
{
    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }
}
