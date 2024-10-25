using DynamicSortingImpl.Features.Other.RequestResponse;
using MediatR;

namespace DynamicSortingImpl.Features.Other;

public class GetOtherQuery : IRequest<GetOtherResponse>
{
    public GetOtherRequest Payload { get; set; } 
    
    public GetOtherQuery(GetOtherRequest payload)
    {
        Payload = payload;
    }
}