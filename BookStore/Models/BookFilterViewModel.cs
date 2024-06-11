using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class BookFilterViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Style { get; set; }
        public string Theme { get; set; }
        public string PublishingHouse { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int? MinPages { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than or equal to {1}")]
        public int? MaxPages { get; set; }

        [Range(
            1,
            double.MaxValue,
            ErrorMessage = "Please enter a value greater than or equal to {1}"
        )]
        public int? MinCost { get; set; }

        [Range(
            1,
            double.MaxValue,
            ErrorMessage = "Please enter a value greater than or equal to {1}"
        )]
        public int? MaxCost { get; set; }

        public DateTime? PublishedAt { get; set; }
    }
}
