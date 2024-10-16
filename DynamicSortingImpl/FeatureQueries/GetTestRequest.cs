using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.FeatureQueries;

public class GetTestRequest : ISortRequest
{
    public IList<SortCondition> Sorts { get; set; }
}