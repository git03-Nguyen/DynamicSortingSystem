using DynamicSortingImpl.Entities;
using DynamicSortingImpl.FeatureQueries.RequestResponse;
using DynamicSortingImpl.Others;
using DynamicSortingImpl.Sortings.LinqExtensions;
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
        var query = _mockRepository.GetMockData();

        query = query.ApplySortCondition(request.Payload.Sorts) as IQueryable<AbcModel>;
        
        return new GetTestResponse()
        {
            Data = query?.ToList() ?? new List<AbcModel>()
        };


    }
}