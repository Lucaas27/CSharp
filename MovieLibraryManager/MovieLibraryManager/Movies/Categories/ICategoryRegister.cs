namespace MovieLibraryManager.Movies.Categories;

public interface ICategoryRegister
{
    IEnumerable<Category> AllCategories { get; }
    Category GetById(int id);
}