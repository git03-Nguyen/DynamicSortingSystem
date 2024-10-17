using DynamicSortingImpl.Entities;
using DynamicSortingImpl.FeatureQueries.Other.RequestResponse;
using MediatR;

namespace DynamicSortingImpl.FeatureQueries.Other;

public class GetOtherHandler : IRequestHandler<GetOtherQuery, GetOtherResponse>
{
    private readonly ILogger<GetOtherHandler> _logger;

    public GetOtherHandler(ILogger<GetOtherHandler> logger)
    {
        _logger = logger;
    }

    public async Task<GetOtherResponse> Handle(GetOtherQuery request, CancellationToken cancellationToken)
    {
        var response = new GetOtherResponse();
        
        return response;
    }
}