namespace MovieLibraryManager.Movies.Categories;

public class CategoryRegister
{

    public IEnumerable<Category> AllCategories =
    [
        new Action(),
        new Comedy(),
        new Drama(),
        new Horror(),
        new Scifi(),
        new Documentary()
    ];


    // public override string ToString()
    // {
    //     return string.Join(Environment.NewLine, AllCategories.Select(c => $"{c.ID}. {c.Name}"));
    // }

}
