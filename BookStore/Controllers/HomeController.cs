using BookStore.Models;
using BookStore.Services;
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
            var filteredBooks = BookService.FilterData(title, author, style, theme, publishingHouse, minPages, maxPages, minCost, maxCost, publishedAt);
            return View("FilteredBooks", filteredBooks);
        }
    }
}
