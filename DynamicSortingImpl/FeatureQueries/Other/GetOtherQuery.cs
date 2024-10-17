using DynamicSortingImpl.FeatureQueries.Other.RequestResponse;
using MediatR;

namespace DynamicSortingImpl.FeatureQueries.Other;

public class GetOtherQuery : IRequest<GetOtherResponse>
{
    public GetOtherRequest Payload { get; set; } 
    
    public GetOtherQuery(GetOtherRequest payload)
    {
        Payload = payload;
    }
}