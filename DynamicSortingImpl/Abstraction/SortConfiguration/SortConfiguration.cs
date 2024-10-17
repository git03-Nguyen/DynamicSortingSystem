using DynamicSortingImpl.Entities;
using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.Abstraction.SortConfiguration;

public abstract class SortConfiguration<T>
{
    protected Dictionary<string, List<string>> AllowedSortFields { get; } = new();
    
    protected Dictionary<string, string> AliasNames { get; } = new();
    
    public abstract void Configure(ISortConfigureOption<T> option);
}


