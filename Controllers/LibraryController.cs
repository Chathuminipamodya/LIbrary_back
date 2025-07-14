using Library.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        public LibraryController(Context context) { 
            Context = context;
        }
        public Context Context { get; set; }

        [HttpPost]
        public ActionResult Register(User user)
        {
            user.AccountStatus = AccountStatus.UNAPROOVED;
            user.UserType = UserType.STUDENT;
            user.CreatedOn = DateTime.Now;

            Context.Users.Add(user);
            Context.SaveChanges();

            
            return Ok(@"Thank you for registering. 
                        Your account has been sent for aprooval. 
                        Once it is aprooved, you will get an email.");
        }
    }
}
