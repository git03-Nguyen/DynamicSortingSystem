using SourceGenerator.Models;

namespace SourceGenerator.Abstraction.SortConfiguration;

public interface ISortConfigureOption<out T>
{
    void ExplicitDeclaration();
    ISortFieldOption AllowField<TProperty>(Func<T, TProperty> field);
}

public interface ISortFieldOption
{
    ISortFieldOption Only(SortDirection direction);
    ISortFieldOption Alias(string alias);
}
