using DynamicSortingImpl.Sortings.Models;
using MediatR;

namespace DynamicSortingImpl.FeatureQueries;

public class GetTestQuery : IRequest<GetTestResponse>, ISortQuery
{
    public ISortRequest Payload { get; set; }

    public GetTestQuery(ISortRequest payload)
    {
        Payload = payload;
    }
}