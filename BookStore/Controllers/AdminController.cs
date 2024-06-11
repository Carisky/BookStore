using BookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var username = model.UserName;
            var password = model.Password;

            if (username == "admin" || password == "admin")
            {
                var json = new { isUserExist = "true" };
                return Json(json);
            }
            else
            {
                return Json(new { isUserExist = "false" });
            }
        }
    }
}
