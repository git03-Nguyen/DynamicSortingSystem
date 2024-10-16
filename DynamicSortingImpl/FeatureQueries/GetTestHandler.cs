using DynamicSortingImpl.Others;
using MediatR;

namespace DynamicSortingImpl.FeatureQueries;

public class GetTestHandler : IRequestHandler<GetTestQuery, GetTestResponse>
{
    private readonly ILogger<GetTestHandler> _logger;
    private readonly IMockRepository _mockRepository;

    public GetTestHandler(ILogger<GetTestHandler> logger, IMockRepository mockRepository)
    {
        _logger = logger;
        _mockRepository = mockRepository;
    }

    public async Task<GetTestResponse> Handle(GetTestQuery request, CancellationToken cancellationToken)
    {
        return new GetTestResponse()
        {
            Data = _mockRepository.GetMockData().ToList()
        };


    }
}