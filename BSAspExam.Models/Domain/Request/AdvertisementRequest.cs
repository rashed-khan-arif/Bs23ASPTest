using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Domain
{
    public class AdvertisementRequest  
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; } 
        public decimal Price { get; set; } 
        public string Slug { get; set; }
        public virtual Product Product { get; set; }
        public ICollection<AdImage> Images { get; set; }
        public virtual AdContactInfo AdContactInfo { get; set; }
        public ICollection<AdTag> Tags { get; set; } 
    } 
}
