using FilmFinder.Data;
using FilmFinder.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FilmFinderContext>(options => options.UseSqlite(connectionString));


builder.Services.AddControllersWithViews();


var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<FilmFinderContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

if (app.Environment.IsStaging() || app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Error/Index");
}


app.UseStaticFiles();

app.UseRouting() ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
