using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmFinder.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = " Please enter a name.")]
        [StringLength(100, ErrorMessage = "Name cannot be more than 100 characters long.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1888, 2024, ErrorMessage = "Year must be between 1888 and 2024.")]
        [Display(Name = "Year")]
        public int? Year { get; set; }

        [Display(Name = "Picture")]
        [Required(ErrorMessage = "Please choose a picture. ")]
        [RegularExpression("^.*\\.(jpg|jpeg|png)$", ErrorMessage = "The picture name must end with .jpg, .jpeg, or .png.")]
        public string? PictureName { get; set; }

        [Display(Name = "Description")]

        [StringLength(300, ErrorMessage = "Description cannot be more than 300 characters long.")]
        public string? Description { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please select a genre.")]
        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public virtual Genre? Genre { get; set; }

        [Required(ErrorMessage = "Please enter a rating.")]
        [Range(1, 10, ErrorMessage = " Rating must be between 1 and 10.")]
        [Display(Name = "Rating")]
        public int? Rating { get; set; }
    }
}
