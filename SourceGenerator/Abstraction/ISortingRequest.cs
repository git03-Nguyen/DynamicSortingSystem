using SourceGenerator.Models;

namespace SourceGenerator.Abstraction;

public interface ISortingRequest<T>
{
    List<SortCondition<T>> Sorts { get; set; }
}