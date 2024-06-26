# Film Finder

## Project Overview
Film Finder is a super handy web app that helps you keep track of all your favorite movies. It's built using ASP.NET Core MVC and makes it a breeze to add, edit, delete, and view detailed information about your movie collection. Plus, you can easily filter movies by genre, making it super simple to organize and find exactly what you're in the mood for. Whether you're a die-hard movie buff or just want to keep tabs on what you've watched, Film Finder has got you covered.

## Features
- **Movie List Display**: Check out all your favorite movies right on the home page, sorted by their ratings.
- **Add New Movie**: Easily add new movies using a straightforward form. Provide all the details like name, year, genre, picture, description, and rating.
- **Edit Existing Movie**: Update any movie in your collection with ease. Make changes to the details as needed.
- **Delete Movie**: Remove movies from your list with a confirmation step to avoid any accidental deletions.
- **Prevent Duplicate Movies**: Film Finder ensures that you don't add two movies with the same name by mistake.
- **Filter Movies by Genre**: Quickly find movies by selecting a genre from a handy dropdown list.
- **Responsive Design**: Enjoy a clean and organized look that works seamlessly on both desktop and mobile devices, thanks to Bootstrap.
- **Error Handling**: Film Finder has got your back with helpful error messages in case anything goes wrong, ensuring a smooth and frustration-free experience.

## Technologies Used
- ASP.NET Core MVC: Used for building the web application.
- Entity Framework Core: Utilized for interacting with the database.
- SQLite: A lightweight database for storing your movie data.
- Bootstrap: Provides a responsive and neat design for the app.

## Database Initialization
Each time the application is run, the database is deleted and recreated with default data. This ensures a consistent starting point for testing and development purposes.

## Usage

### Adding a Movie
- Click on the "Add New Movie" button.
- Fill in all the movie details:
  - **Name**: Enter the movie's name.
  - **Year**: Add the release year.
  - **Genre**: Select the genre from the dropdown list.
  - **Picture**: Optionally, you can upload a picture.
  - **Description**: Provide a brief description.
  - **Rating**: Assign a rating from 1 to 10.
- Click "Add Movie" to save it to your list.

### Editing a Movie
- To update a movie, click the "Edit" button next to the movie you want to modify.
- Make the necessary changes to the details.
- Click "Save" to apply the changes.

### Deleting a Movie
- To remove a movie from your list, click the "Delete" button next to the movie you want to delete.
- Confirm the deletion when prompted.

### Filtering Movies by Genre
- On the home page, choose a specific genre from the dropdown menu.
- Click "Filter" to see only the movies in that genre.

