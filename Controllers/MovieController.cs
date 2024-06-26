using FilmFinder.Models;
using FilmFinder.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace FilmFinder.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(IMovieRepository movieRepository, IGenreRepository genreRepository, IWebHostEnvironment webHostEnvironment)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(int? genreId)
        {
            var genres = _genreRepository.GetGenres();
            ViewBag.Genres = genres;

            var movies = genreId.HasValue
                ? _movieRepository.GetMoviesByGenre(genreId.Value)
                : _movieRepository.GetMovies();


            return View(movies);
        }

    public IActionResult AddMovie()
        {
            var genres = _genreRepository.GetGenres();
            ViewBag.Genres = genres;
            return View();
        }


        [HttpPost]
        public IActionResult AddMovie(Movie movie,  IFormFile Picture)
        {
            if (_movieRepository.MovieExists(movie.Name))
            {
                ModelState.AddModelError("Name", "A movie with the same name already exists.");
            }

            if (ModelState.IsValid)
            {
                if (Picture != null && Picture.Length > 0)
                {
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Picture.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Picture.CopyTo(fileStream);
                    }
                    movie.PictureName = Picture.FileName;
                }


                try
                {
                    _movieRepository.AddMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Unable to save movie. Please try again.");
                }
            }

            var genres = _genreRepository.GetGenres();
            ViewBag.Genres = genres;
            return View(movie);


        }


        public IActionResult EditMovie(int id)
        {
            try
            {
                var movie  = _movieRepository.GetMovieById(id);

                if (movie == null)
                {
                    return NotFound($"Movie not found.");
                }

                var genres = _genreRepository.GetGenres();
                ViewBag.Genres = genres;
                return View (movie);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving movie for editing:  {ex.Message}");
                return StatusCode(500,  "Internal server error while retrieving movie for editing.");
            }
        }



        [HttpPost]
        public IActionResult EditMovie(int id, Movie movie, IFormFile PhotoFile)
        {
            if (id != movie.Id)
            {
                return NotFound(); 
            }

            ModelState.Remove("PhotoFile");
            if (ModelState.IsValid) 
            {
                try
                {
                    var movieInDb = _movieRepository.GetMovieById(id);
                    if (movieInDb == null)
                    {
                        return NotFound();           }

                    if (PhotoFile != null && PhotoFile.Length > 0)
                    {
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", PhotoFile.FileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            PhotoFile.CopyTo(fileStream);
                        }
                        movie.PictureName = PhotoFile.FileName;
                    }
                    else
                    {
                        movie.PictureName = movieInDb.PictureName;
                    }

                    _movieRepository.UpdateMovie(id, movie);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error while updating movie: {ex.Message}");
                    ModelState.AddModelError("", "An error occurred while updating the movie. Please try again.");
                }
            }

            var genres = _genreRepository.GetGenres();
            ViewBag.Genres = genres;
            return View(movie);
        }



        public IActionResult DeleteMovie(int id) 
        {
            var movie = _movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }  
         
        [HttpPost]
        public IActionResult DeleteMovieConfirmed(int id)
        {
            _movieRepository.DeleteMovie(id); 
            return RedirectToAction(nameof(Index));
        }
    }


}

