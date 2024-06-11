using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        public string Title { get; }

        public string Author { get; }

        public string Style { get; }

        public string Theme { get; }

        public string PublishingHouse { get; }

        public int PagesCount { get; }

        public int Cost { get; }

        public DateTime PublishedAt { get; }

        public Book(
            string title,
            string author,
            string style,
            string theme,
            string publishingHouse,
            int pagesCount,
            int cost,
            DateTime publishedAt
        )
        {
            Title = title;
            Author = author;
            Style = style;
            Theme = theme;
            PublishingHouse = publishingHouse;
            PagesCount = pagesCount;
            Cost = cost;
            PublishedAt = publishedAt;
        }

        public bool IsValid()
        {
            return Title != null
                && Author != null
                && Style != null
                && Theme != null
                && PublishingHouse != null
                && PagesCount != 0;
        }
    }
}
