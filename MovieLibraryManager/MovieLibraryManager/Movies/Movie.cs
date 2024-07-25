using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.Movies;

public class Movie(string title, string director, IEnumerable<Category> category, int releaseYear, double rating)
{
    public Guid ID { get; } = Guid.NewGuid(); // Unique identifier for the movie.
    public string Title { get; } = title;
    public string Director { get; } = director;
    public IEnumerable<Category> Category { get; } = category;
    public int ReleaseYear { get; } = releaseYear;
    public double Rating { get; } = rating;

    public override string ToString()
    {

        var categories = string.Join(", ", Category.Select(c => c.ToString()));
        return string.Join(Environment.NewLine, $"ID: {ID}, Title: {Title}, Director: {Director}, Category: {categories}, Release Year: {ReleaseYear}, Rating: {Rating}");
    }

}