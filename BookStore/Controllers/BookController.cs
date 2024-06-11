using System;
using System.Text;
using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        [HttpPost]
        public IActionResult CreateFile(
            string title,
            string author,
            string style,
            string theme,
            string publishingHouse,
            int pagesCount,
            decimal cost,
            string publishedAt
        )
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

        [HttpGet]
        public IActionResult FilterBooks(BookFilterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Home/Index.cshtml", model);
            }

            var filteredBooks = BookService.FilterData(
                model.Title,
                model.Author,
                model.Style,
                model.Theme,
                model.PublishingHouse,
                model.MinPages,
                model.MaxPages,
                model.MinCost,
                model.MaxCost,
                model.PublishedAt
            );
            return View("FilteredBooks", filteredBooks);
        }

        [HttpGet]
        public IActionResult GetFilteredBooksJson(BookFilterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Handle validation errors (e.g., return a JSON response with validation error details)
                return BadRequest(ModelState);
            }

            var filteredBooks = BookService.FilterData(
                model.Title,
                model.Author,
                model.Style,
                model.Theme,
                model.PublishingHouse,
                model.MinPages,
                model.MaxPages,
                model.MinCost,
                model.MaxCost,
                model.PublishedAt
            );
            return Json(filteredBooks);
        }
    }
}
