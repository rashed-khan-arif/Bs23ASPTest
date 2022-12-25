using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Domain
{
    public class UserComment : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Comments { get; set; }
        public int AdvertisementId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<UserComment> Childs { get; set; } 
        public virtual Advertisement Advertisement { get; set; }
        public virtual ApplicationUser CreatedByUser { get; set; }
        public virtual UserComment Parent { get; set; }

    }
}
