using FilmFinder.Models;

namespace FilmFinder.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();
        void AddMovie(Movie movie);
        void UpdateMovie(int id, Movie movie);
        void DeleteMovie(int id);
        IEnumerable<Movie> GetMoviesByRating();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);

        Movie GetMovieById(int id);
        Genre GetGenreById(int id);

        bool MovieExists(string name);

    }
}
