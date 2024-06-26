using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmFinder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    PictureName = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Science Fiction" },
                    { 3, "Suspense" },
                    { 4, "Comedy" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "GenreId", "Name", "PictureName", "Rating", "Year" },
                values: new object[,]
                {
                    { 1, "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", 2, "Inception", "inception.jpg", 8, 2010 },
                    { 2, "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.", 1, "The Dark Knight", "the_dark_knight.jpg", 9, 2008 },
                    { 3, "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", 3, "Pulp Fiction", "pulp_fiction.jpg", 9, 1994 },
                    { 4, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", 5, "The Godfather", "the_godfather.jpg", 9, 1972 },
                    { 5, "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing.", 4, "The Hangover", "the_hangover.jpg", 7, 2009 },
                    { 6, "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", 2, "Interstellar", "interstellar.jpg", 8, 2014 },
                    { 7, "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", 2, "The Matrix", "the_matrix.jpg", 8, 1999 },
                    { 8, "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75.", 5, "Forrest Gump", "forrest_gump.jpg", 8, 1994 },
                    { 9, "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", 1, "Gladiator", "gladiator.jpg", 8, 2000 },
                    { 10, "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", 5, "The Shawshank Redemption", "the_shawshank_redemption.jpg", 9, 1994 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
