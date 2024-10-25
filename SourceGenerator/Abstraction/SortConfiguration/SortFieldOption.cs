using SourceGenerator.Models;

namespace SourceGenerator.Abstraction.SortConfiguration;

public class SortFieldOption<T> : ISortFieldOption
{
    private readonly string _fieldName;
    private readonly SortConfiguration<T> _configuration;

    public SortFieldOption(string fieldName, SortConfiguration<T> configuration)
    {
        _fieldName = fieldName;
        _configuration = configuration;
    }

    public ISortFieldOption Only(SortDirection direction)
    {
        throw new NotImplementedException();
    }

    public ISortFieldOption Alias(string alias)
    {
        throw new NotImplementedException();
    }
}
