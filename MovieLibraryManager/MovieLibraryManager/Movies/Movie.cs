using MovieLibraryManager.Movies.Categories;

namespace MovieLibraryManager.Movies;

public class Movie(string title, string director, List<Category> category, int releaseYear)
{
    private static int _nextId = 1; // Static field to keep track of the next ID to be assigned.

    public int ID { get; } = _nextId++;
    public string Title { get; } = title;
    public string Director { get; } = director;
    public IEnumerable<Category> Category { get; } = category;
    public int ReleaseYear { get; } = releaseYear;

}