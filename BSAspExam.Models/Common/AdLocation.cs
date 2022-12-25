using BSAspExam.Models.Domain;
using BSAspExam.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Common
{
    public class AdLocation : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public LocationType Type { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual AdLocation Parent { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<AdLocation> Childs { get; set; }
    }

    public enum LocationType
    {
        City = 0,
        Division = 1
    }
}
