namespace MovieLibraryManager.Movies.Categories;

public class CategoryRegister : ICategoryRegister
{

    public IEnumerable<Category> AllCategories { get; } =
    [
        new Action(),
        new Comedy(),
        new Drama(),
        new Horror(),
        new Scifi(),
        new Documentary()
    ];

    public Category GetById(int id)
    {
        foreach (var cat in AllCategories)
        {
            if (cat.ID == id)
            {
                return cat;

            }
        }
        return null;
    }
}
