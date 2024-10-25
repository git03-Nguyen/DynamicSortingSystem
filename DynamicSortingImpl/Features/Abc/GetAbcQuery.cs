using DynamicSortingImpl.Features.Abc.RequestResponse;
using MediatR;

namespace DynamicSortingImpl.Features.Abc;

public class GetAbcQuery : IRequest<GetAbcResponse>
{
    public GetAbcRequest Payload { get; set; }

    public GetAbcQuery(GetAbcRequest payload)
    {
        Payload = payload;
    }
}