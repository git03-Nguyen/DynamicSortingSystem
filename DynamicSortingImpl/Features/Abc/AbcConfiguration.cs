using DynamicSortingImpl.Core.Entities;
using SourceGenerator.Abstraction.SortConfiguration;
using SourceGenerator.Models;

namespace DynamicSortingImpl.Features.Abc;

public class AbcConfiguration<T> : SortConfiguration<AbcModel>
{
    public override void Configure(ISortConfigureOption<AbcModel> option)
    {
        option.ExplicitDeclaration();
        option.AllowField(x => x.Name)
            .Only(SortDirection.ASC)
            .Alias("custom_name");
    }
}