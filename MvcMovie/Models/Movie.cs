using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a movie title.")]
    [StringLength(60, MinimumLength = 3, ErrorMessage = "Title must contain 3 to 60 characters.")]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    [Required(ErrorMessage = "Please choose a release date.")]
    public DateTime ReleaseDate { get; set; }

    [Required(ErrorMessage = "Please enter a genre.")]
    [StringLength(30)]
    public string Genre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "1000.00", ErrorMessage = "Price must be between 0.01 and 1000.00.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [StringLength(5)]
    [RegularExpression(@"^(G|PG|PG-13|R|NC-17)$", ErrorMessage = "Rating must be G, PG, PG-13, R or NC-17.")]
    public string? Rating { get; set; }
}
