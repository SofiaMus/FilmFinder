using FilmFinder.Models;

namespace FilmFinder.Repositories
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetGenres();

        Genre GetGenreById(int id);
    }
}
