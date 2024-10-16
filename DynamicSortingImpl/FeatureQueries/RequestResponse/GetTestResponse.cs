using DynamicSortingImpl.Entities;
using DynamicSortingImpl.Sortings.Models;

namespace DynamicSortingImpl.FeatureQueries.RequestResponse;

public class GetTestResponse
{
    public List<AbcModel> Data { get; set; } = new();
}