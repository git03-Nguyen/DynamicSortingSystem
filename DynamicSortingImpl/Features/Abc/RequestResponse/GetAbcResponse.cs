using DynamicSortingImpl.Core.Entities;

namespace DynamicSortingImpl.Features.Abc.RequestResponse;

public class GetAbcResponse
{
    public List<AbcModel> Data { get; set; } = new();
}