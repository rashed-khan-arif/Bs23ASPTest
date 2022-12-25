using BSAspExam.Models.Common;
using BSAspExam.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Identity
{
    public class ApplicationUser : IdentityUser<int>
    { 
        public virtual ICollection<UserBlacklist> UserBlacklists { get; set; } 
        public virtual ICollection<Advertisement> Advertisements { get; set; }
        public virtual ICollection<AdLocation> Locations { get; set; }
    }
}
