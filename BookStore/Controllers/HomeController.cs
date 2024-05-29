using System;
using System.Linq;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilterBooks(
            string title,
            string author,
            string style,
            string theme,
            string publishingHouse,
            int? minPages,
            int? maxPages,
            int? minCost,
            int? maxCost,
            DateTime? publishedAt
        )
        {
            var filteredBooks = BookService.FilterData(
                title,
                author,
                style,
                theme,
                publishingHouse,
                minPages,
                maxPages,
                minCost,
                maxCost,
                publishedAt
            );
            return View("FilteredBooks", filteredBooks);
        }

        [HttpGet]
        public IActionResult GetFilteredBooksJson(
            string title,
            string author,
            string style,
            string theme,
            string publishingHouse,
            int? minPages,
            int? maxPages,
            int? minCost,
            int? maxCost,
            DateTime? publishedAt
        )
        {
            var filteredBooks = BookService.FilterData(
                title,
                author,
                style,
                theme,
                publishingHouse,
                minPages,
                maxPages,
                minCost,
                maxCost,
                publishedAt
            );
            return Json(filteredBooks);
        }
    }
}
