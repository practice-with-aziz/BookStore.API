using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.API.Models
{
    public class Book
    {
        public int BookId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;

        [Range(0.01,10000)]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        public Genre Genre { get; set; }
    }
    public enum Genre
    {
        Fiction,
        NonFiction,
        Mystery,
        Thriller,
        ScienceFiction,
        Fantasy,
        Romance,
        Horror,
        HistoricalFiction,
        Biography,
        Autobiography,
        SelfHelp,
        Business,
        Programming,
        Technology,
        Philosophy,
        Psychology,
        Science,
        History,
        Poetry,
        Drama,
        Adventure,
        YoungAdult,
        ChildrensComics
    }
}
