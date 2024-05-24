using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        public IActionResult CreateFile(string title, string author, string style, string theme, string publishingHouse, int pagesCount, decimal cost, string publishedAt)
        {
            var content = new StringBuilder();
            content.AppendLine($"Title: {title}");
            content.AppendLine($"Author: {author}");
            content.AppendLine($"Style: {style}");
            content.AppendLine($"Theme: {theme}");
            content.AppendLine($"Publishing House: {publishingHouse}");
            content.AppendLine($"Pages Count: {pagesCount}");
            content.AppendLine($"Cost: {cost}");
            content.AppendLine($"Published At: {publishedAt}");

            var fileBytes = Encoding.UTF8.GetBytes(content.ToString());
            var fileName = $"{title}_{author}.txt";

            return File(fileBytes, "text/plain", fileName);
        }
    }
}
