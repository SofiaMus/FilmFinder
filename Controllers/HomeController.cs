using FilmFinder.Models;
using FilmFinder.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmFinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;

        public HomeController(IMovieRepository movieRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
        }

        public IActionResult Index(int?  genreId)
        {
            var genres = _genreRepository.GetGenres();
            ViewBag.Genres = genres;

            IEnumerable<Movie> movies;

            if (genreId.HasValue)
            {
                movies = _movieRepository.GetMoviesByGenre(genreId.Value);
            }
            else
            {
                movies = _movieRepository.GetMoviesByRating();               }

            return View(movies);
        }
    }
}
