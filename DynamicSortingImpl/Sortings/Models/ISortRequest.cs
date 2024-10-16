using DynamicSortingImpl.Abstraction;

namespace DynamicSortingImpl.Sortings.Models;

public interface ISortRequest : IRequestModel
{
    IList<SortCondition> Sorts { get; set; }
}