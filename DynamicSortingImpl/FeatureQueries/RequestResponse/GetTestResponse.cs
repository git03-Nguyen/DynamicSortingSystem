using DynamicSortingImpl.Entities;

namespace DynamicSortingImpl.FeatureQueries.RequestResponse;

public class GetTestResponse
{
    public List<AbcModel> Data { get; set; } = new();
}