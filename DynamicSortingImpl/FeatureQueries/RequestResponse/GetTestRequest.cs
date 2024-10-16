using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.FeatureQueries.RequestResponse;

public class GetTestRequest : ISortRequest
{
    public IList<SortCondition> Sorts { get; set; }
}