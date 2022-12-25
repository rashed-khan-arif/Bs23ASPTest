using BSAspExam.Models.Common;
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

        public virtual Product Product { get; set; }
        public virtual AdLocation Location { get; set; }
        public ICollection<AdImage> Images { get; set; }
    }

    public enum AdStatus
    {
        Unknown = 0,
        Published = 1,
        UnPublished = 2,
        Banned = 3
    }

    public class Tag : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }

    public class AdTag
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int TagId { get; set; }
        public bool Active { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Advertisement Advertisement { get; set; }
    }

    public class ProductTag
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }
        public bool Active { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Product Product { get; set; }
    }

    public class AdImage : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }

    public class AdContactInfo
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
