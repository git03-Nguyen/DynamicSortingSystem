namespace SourceGenerator.Abstraction.SortConfiguration;

public class SortConfigureOption<T> : ISortConfigureOption<T>
{
    private readonly SortConfiguration<T> _configuration;

    public SortConfigureOption(SortConfiguration<T> configuration)
    {
        _configuration = configuration;
    }

    public void ExplicitDeclaration()
    {
        // Implementation for explicit declaration logic, if needed
    }

    public ISortFieldOption AllowField<TProperty>(Func<T, TProperty> field)
    {
        // Get field name using reflection or expression tree
        var fieldName = typeof(T).GetProperty(nameof(field)).Name; // This may need adjustment based on your expression

        return new SortFieldOption<T>(fieldName, _configuration);
    }
}