namespace MovieLibraryManager.Movies.Categories;

public abstract class Category
{
    public abstract int ID { get; }
    public abstract string Name { get; }
    // public virtual IEnumerable<Movie> Movies { get; } = [];


    public override string ToString() => $"{ID}. {Name}";

}
