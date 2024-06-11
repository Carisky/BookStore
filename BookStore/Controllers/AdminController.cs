using System.Data.SqlTypes;
using BookStore.Models;
using BookStore.Services;
using BookStore.Utils;
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
        public IActionResult AddBook([FromBody] Book book)
        {
            if (!book.IsValid())
            {
                return BadRequest(book);
            }

            BookService.WriteBookToFile(book);
            BooksStore.LoadStore("storage.txt");
            return Ok();
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
