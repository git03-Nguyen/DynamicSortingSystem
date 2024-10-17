using DynamicSortingImpl.Abstraction.SortConfiguration;
using DynamicSortingImpl.Entities;
using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.FeatureQueries.Test.Config;

public class TestSortConfiguration<T> : SortConfiguration<AbcModel>
{
    public override void Configure(ISortConfigureOption<AbcModel> option)
    {
        option.ExplicitDeclaration();
        option.AllowField(x => x.Name)
            .Only(SortDirection.Ascending)
            .Alias("custom_name");
    }
}