using DynamicSortingImpl.Core.Entities;
using SourceGenerator.Attributes;

namespace DynamicSortingImpl.Features.Abc.RequestResponse
{
    [SortableRequest(typeof(AbcModel))]
    public partial class GetAbcRequest
    {
    }
}

