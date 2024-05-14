using System;
using System.Collections.Generic;
using System.IO;
using BookStore.Models;

namespace BookStore.Utils
{
    public static class BooksStore
    {
        private static List<Book> _books;
        private static readonly object _lock = new object();

        public static void LoadStore(string path)
        {
            lock (_lock)
            {
                _books = new List<Book>();

                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string title = line.Trim();
                            string author = reader.ReadLine().Trim();
                            string style = reader.ReadLine().Trim();
                            string theme = reader.ReadLine().Trim();
                            string publishingHouse = reader.ReadLine().Trim();
                            int pagesCount = int.Parse(reader.ReadLine().Trim());
                            int cost = int.Parse(reader.ReadLine().Trim());
                            DateTime publishedAt = DateTime.Parse(reader.ReadLine().Trim());

                            _books.Add(
                                new Book(
                                    title,
                                    author,
                                    style,
                                    theme,
                                    publishingHouse,
                                    pagesCount,
                                    cost,
                                    publishedAt
                                )
                            );

                            reader.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while reading from file: {ex.Message}");
                }
            }
        }

        public static List<Book> GetData()
        {
            return _books;
        }
    }
}
