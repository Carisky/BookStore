using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PhraseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
