namespace SourceGenerator.Models;

public class SortCondition<T>
{
    public string SortBy { get; set; }
    public SortDirection OrderBy { get; set; }
}

public enum SortDirection
{
    ASC,
    DESC
}