using FilmFinder.Data;
using FilmFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmFinder.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private FilmFinderContext _context;

        public MovieRepository(FilmFinderContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies!;
        }

        public void AddMovie(Movie animal)
        {
            _context.Movies!.Add(animal);
            _context.SaveChanges();
        }

        public void UpdateMovie(int id, Movie updatedMovie)
        {
            try
            {
                var movieInDb = _context.Movies.FirstOrDefault(a => a.Id == id);

                if (movieInDb == null)
                {
                    throw new InvalidOperationException($"Movie with ID {id} not found.");
                }

                movieInDb.Name = updatedMovie.Name;
                movieInDb.Year = updatedMovie.Year;
                movieInDb.PictureName = updatedMovie.PictureName;
                movieInDb.Description = updatedMovie.Description;
                movieInDb.GenreId = updatedMovie.GenreId;
                movieInDb.Rating = updatedMovie.Rating;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while updating movie in the database: {ex.Message}");
                throw; 
            }
        }


        public void DeleteMovie(int id)
        {
            var animal = _context.Movies!.Single(a => a.Id == id);
            _context.Movies!.Remove(animal);
            _context.SaveChanges();
        }

        public IEnumerable<Movie> GetMoviesByRating()
        {
            return _context.Movies.Include(a => a.Genre)
                                  .OrderByDescending(a => a.Rating)
                                  .ToList();
        }

            public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _context.Movies

                .Where(a => a.GenreId == genreId)
                .ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _context.Movies
                .Include(a => a.Genre)

                .FirstOrDefault(a => a.Id == id);
        }


        public Genre GetGenreById(int id)
        {
            return _context.Genres.Find(id);
        }

        public bool MovieExists(string name)
        {
            return _context.Movies.Any(a => a.Name == name);
        }
    }
}
