using BookStore.Models;
using BookStore.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilterBooks(string title, string author, string style, string theme, string publishingHouse, int? minPages, int? maxPages, int? minCost, int? maxCost, DateTime? publishedAt)
        {
            
            var filteredBooks = BooksStore.GetData().Where(book =>
                (string.IsNullOrEmpty(title) || book.Title.Contains(title)) &&
                (string.IsNullOrEmpty(author) || book.Author.Contains(author)) &&
                (string.IsNullOrEmpty(style) || book.Style.Contains(style)) &&
                (string.IsNullOrEmpty(theme) || book.Theme.Contains(theme)) &&
                (string.IsNullOrEmpty(publishingHouse) || book.PublishingHouse.Contains(publishingHouse)) &&
                (!minPages.HasValue || book.PagesCount >= minPages.Value) &&
                (!maxPages.HasValue || book.PagesCount <= maxPages.Value) &&
                (!minCost.HasValue || book.Cost >= minCost.Value) &&
                (!maxCost.HasValue || book.Cost <= maxCost.Value) &&
                (!publishedAt.HasValue || book.PublishedAt.Date == publishedAt.Value.Date)
            );

            
            return View("FilteredBooks", filteredBooks);
        }
    }
}
