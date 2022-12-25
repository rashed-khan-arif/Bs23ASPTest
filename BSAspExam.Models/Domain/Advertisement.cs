using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Domain
{
    public class Advertisement : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool Verified { get; set; }
        public string Slug { get; set; }
        public bool Active { get; set; }
        public AdStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual Product Product { get; set; }
        public virtual AdLocation Location { get; set; }
        public virtual AdContactInfo AdContactInfo { get; set; }
        public ICollection<AdImage> Images { get; set; }
        public ICollection<AdMessage> Messages { get; set; }
        public ICollection<AdTag> Tags { get; set; }
        public virtual ICollection<UserBlacklist> UserBlacklists { get; set; }
    }

    public enum AdStatus
    {
        Unknown = 0,
        Published = 1,
        UnPublished = 2,
        Banned = 3
    }
}
