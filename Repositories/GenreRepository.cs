using FilmFinder.Data;
using FilmFinder.Models;

namespace FilmFinder.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private FilmFinderContext _context;

        public GenreRepository(FilmFinderContext context)
        {
            _context = context;
        }

        public IEnumerable<Genre> GetGenres()
        {

            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.Find(id);
        }
    }
}
