using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BookStore.Models;
using BookStore.Utils;
using Newtonsoft.Json;

namespace BookStore.Services
{
    public static class BookService
    {
        public static List<Book> GetData()
        {
            return BooksStore.GetData();
        }

        public static void WriteBookToFile(Book book)
        {
            BooksGenerator.WriteBookToFile(book, "storage.txt");
        }

        public static IEnumerable<Book> FilterData(
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
            var filtered = GetData()
                .Where(book =>
                    (string.IsNullOrEmpty(title) || book.Title.Contains(title))
                    && (string.IsNullOrEmpty(author) || book.Author.Contains(author))
                    && (string.IsNullOrEmpty(style) || book.Style.Contains(style))
                    && (string.IsNullOrEmpty(theme) || book.Theme.Contains(theme))
                    && (
                        string.IsNullOrEmpty(publishingHouse)
                        || book.PublishingHouse.Contains(publishingHouse)
                    )
                    && (!minPages.HasValue || book.PagesCount >= minPages.Value)
                    && (!maxPages.HasValue || book.PagesCount <= maxPages.Value)
                    && (!minCost.HasValue || book.Cost >= minCost.Value)
                    && (!maxCost.HasValue || book.Cost <= maxCost.Value)
                    && (!publishedAt.HasValue || book.PublishedAt.Date == publishedAt.Value.Date)
                );

            return filtered;
        }
    }
}
