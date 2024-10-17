namespace DynamicSortingImpl.Abstraction;

public abstract class ListResponseModel<T> : ErrorResponse
{
    public List<T> Data { get; set; } = new();
}