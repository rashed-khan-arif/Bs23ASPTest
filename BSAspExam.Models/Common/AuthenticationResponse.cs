using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAspExam.Models.Common
{
    public class AuthenticationResponse
    {
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
