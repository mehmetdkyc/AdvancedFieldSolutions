using Data.Business.Abstract;
using Data.Business.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdvancedFieldSolutions.Controllers
{
    public class LoginController : Controller
    {
        private IUserService userService;
        public LoginController()
        {
            userService = new UserManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            //we check the username and password if it is true or not and also set the cookie when it is ok. 
            var userCheck = userService.GetAllUsers().FirstOrDefault(x => x.Username == userName && x.Password == password);
            if (userCheck != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }
    }
}
