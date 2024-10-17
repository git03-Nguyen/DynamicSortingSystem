using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.Abstraction;

public abstract class ListRequestModel<T>
{
    public List<SortCondition<T>>? Sorts { get; set; } = null;
    public List<SortCondition<T>>? Filter { get; set; } = null;
}