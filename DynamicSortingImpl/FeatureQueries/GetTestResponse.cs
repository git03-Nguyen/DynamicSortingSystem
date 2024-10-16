using DynamicSortingImpl.Entities;

namespace DynamicSortingImpl.FeatureQueries;

public class GetTestResponse
{
    public List<AbcModel> Data { get; set; } = new();
}