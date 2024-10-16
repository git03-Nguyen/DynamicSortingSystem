namespace DynamicSortingImpl.Sortings.Models;

public class SortCondition
{
    public string Field { get; set; }
    public SortDirection Direction { get; set; }
}

public enum SortDirection
{
    Ascending,
    Descending
}