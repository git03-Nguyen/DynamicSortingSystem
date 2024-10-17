namespace DynamicSortingImpl.Sortings.Models;

public class SortCondition<T>
{
    public string Field { get; set; }
    public SortDirection Direction { get; set; }
}

public enum SortDirection
{
    Ascending,
    Descending
}