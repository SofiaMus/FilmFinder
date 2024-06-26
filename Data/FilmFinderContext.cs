using FilmFinder.Models;
using Microsoft.EntityFrameworkCore;
namespace FilmFinder.Data
{
    public class FilmFinderContext : DbContext
    {
        public FilmFinderContext(DbContextOptions<FilmFinderContext> options) : base(options)
        {
        }

        public DbSet<Movie>? Movies { get; set; }

        public DbSet<Genre>? Genres { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Genre>().HasData( 
               new Genre { Id = 1, Name = "Action" },
               new Genre { Id = 2, Name = "Science Fiction" },
               new Genre { Id = 3, Name = "Suspense" },
               new Genre { Id = 4, Name = "Comedy" },
               new Genre { Id = 5, Name = "Drama"  }
           );


            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Inception",
                    Year = 2010,
                    PictureName = "inception.jpg",
                    Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    GenreId = 2,
                    Rating = 8
                },
                new Movie
                {
                    Id = 2,
                    Name = "The Dark Knight",
                    Year = 2008,
                    PictureName = "the_dark_knight.jpg",
                    Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                    GenreId = 1,
                    Rating = 9
                },
                new Movie
                {
                    Id = 3, 
                    Name = "Pulp Fiction",
                    Year = 1994,
                    PictureName = "pulp_fiction.jpg",
                    Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    GenreId = 3,
                    Rating = 9
                },
                new Movie
                {
                    Id = 4,
                    Name = "The Godfather",
                    Year = 1972,
                    PictureName = "the_godfather.jpg",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    GenreId = 5,
                    Rating = 9
                },
                new  Movie
                {
                    Id = 5,
                    Name = "The Hangover",
                    Year = 2009,
                    PictureName = "the_hangover.jpg",
                    Description = "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing.",
                    GenreId = 4,
                    Rating = 7
                },
                new Movie
                {
                    Id = 6,
                    Name = "Interstellar",
                    Year = 2014,
                    PictureName = "interstellar.jpg",
                    Description = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",  
                    GenreId = 2,
                    Rating = 8
                },
                new Movie
                {
                    Id = 7,
                    Name = "The Matrix",
                    Year = 1999,
                    PictureName = "the_matrix.jpg",
                    Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    GenreId = 2,
                    Rating = 8
                },
                new Movie
                {
                    Id = 8,
                    Name = "Forrest Gump",
                    Year = 1994,
                    PictureName = "forrest_gump.jpg",

                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75.",
                    GenreId = 5,
                    Rating = 8
                },
                new Movie
                {
                    Id = 9,
                    Name = "Gladiator",
                    Year = 2000,
                    PictureName = "gladiator.jpg",
                    Description = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                    GenreId = 1,
                    Rating = 8
                },
                new Movie
                {
                    Id = 10,

                    Name = "The Shawshank Redemption",
                    Year = 1994,
                    PictureName = "the_shawshank_redemption.jpg",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    GenreId = 5,
                    Rating = 9
                }
            );

        }
    }
}