using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Faker;

namespace BookStore.Utils
{
    public static class BooksGenerator
    {
        public static void GenerateBooks(int count, string filePath)
        {
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                Console.WriteLine($"The file '{filePath}' already contains data. No new books generated.");
                return;
            }
            var tasks = new List<Task>();
            for (int i = 0; i < count; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    GenerateAndWriteBook(filePath);
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }

        private static void GenerateAndWriteBook(string filePath)
        {
            Book book = new Book(
                Company.Name(),
                Name.FullName(),
                Company.BS(),
                Lorem.Words(1).First(),
                Company.Name(),
                RandomNumber.Next(100, 1000),
                RandomNumber.Next(10, 100),
                new DateTime(2000, 1, 20)
            );

            WriteBookToFile(book, filePath);
        }

        private static void WriteBookToFile(Book book, string filePath)
        {
            try
            {
                lock (filePath)
                {
                    using (StreamWriter writer = new StreamWriter(filePath, true))
                    {
                        writer.WriteLine($"{book.Title}");
                        writer.WriteLine($"{book.Author}");
                        writer.WriteLine($"{book.Style}");
                        writer.WriteLine($"{book.Theme}");
                        writer.WriteLine($"{book.PublishingHouse}");
                        writer.WriteLine($"{book.PagesCount}");
                        writer.WriteLine($"{book.Cost}");
                        writer.WriteLine($"{book.PublishedAt}");
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while writing to file: {ex.Message}");
            }
        }
    }
}
