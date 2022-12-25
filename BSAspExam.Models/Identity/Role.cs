using Microsoft.AspNetCore.Identity;

namespace BSAspExam.Models.Identity
{
    public class Role : IdentityRole<int>
    {
        public static string SuperAdmin = "super_admin";
        public static string Admin = "admin";
        public static string User = "user"; 


        public Role()
        {

        }

        public int Level { get; set; }
    }
}