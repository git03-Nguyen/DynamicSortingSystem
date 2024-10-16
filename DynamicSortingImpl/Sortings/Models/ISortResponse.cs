namespace DynamicSortingImpl.Sortings.Models;

public interface ISortResponse
{
    IEnumerable<ISortData> Data { get; set; }
}