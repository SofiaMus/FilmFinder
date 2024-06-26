using System.ComponentModel.DataAnnotations;

namespace FilmFinder.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Genre:")]
        public string? Name { get; set; }

    }
}
