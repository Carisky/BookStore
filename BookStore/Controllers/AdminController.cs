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
    }
}
