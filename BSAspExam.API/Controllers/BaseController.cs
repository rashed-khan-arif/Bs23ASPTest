using BSAspExam.API.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSAspExam.API.Controllers
{
   
    public abstract class BaseController : ControllerBase
    {
        public int CurrentUserId => User.GetUserId();
    }
}
