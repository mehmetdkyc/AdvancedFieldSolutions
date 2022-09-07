using Data.Business.Abstract;
using Data.Business.Concrete;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedFieldSolutions.Controllers
{
    public class RegisterController : Controller
    {
        private IUserService userService;
        public RegisterController()
        {
            userService = new UserManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(string userName, string password)
        {
            //we create user here using our userService
            User _user = new User()
            {
                Username = userName,
                Password = password
            };
            userService.CreateUser(_user);

            return RedirectToAction("Index", "Login");
        }
    }
}
