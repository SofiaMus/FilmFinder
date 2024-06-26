using FilmFinder.Data;
using Microsoft.AspNetCore.Mvc;

public class TestController : Controller
{
    private readonly FilmFinderContext _context;

    public TestController(FilmFinderContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var moviesCount = _context.Movies.Count();
        return Content($"There are {moviesCount} movies in the database.");
    }
}
