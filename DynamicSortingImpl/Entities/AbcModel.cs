using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.Entities;

public class AbcModel : ISortData 
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}