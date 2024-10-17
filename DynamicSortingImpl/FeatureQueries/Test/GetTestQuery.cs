using DynamicSortingImpl.FeatureQueries.Test.RequestResponse;
using MediatR;

namespace DynamicSortingImpl.FeatureQueries.Test;

public class GetTestQuery : IRequest<GetTestResponse>
{
    public GetTestRequest Payload { get; set; }

    public GetTestQuery(GetTestRequest payload)
    {
        Payload = payload;
    }
}