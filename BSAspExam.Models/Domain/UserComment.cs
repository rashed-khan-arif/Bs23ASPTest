using BSAspExam.Models.Common;
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
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }

    }

    public class UserMessage : IEntity
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Active { get; set; }
    }


}
