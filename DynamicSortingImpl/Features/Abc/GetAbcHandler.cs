using DynamicSortingImpl.Core;
using DynamicSortingImpl.Core.Entities;
using DynamicSortingImpl.Features.Abc.RequestResponse;
using DynamicSortingImpl.Sortings.LinqExtensions;
using MediatR;

namespace DynamicSortingImpl.Features.Abc;

public class GetAbcHandler : IRequestHandler<GetAbcQuery, GetAbcResponse>
{
    private readonly ILogger<GetAbcHandler> _logger;
    private readonly IMockRepository _mockRepository;

    public GetAbcHandler(
        ILogger<GetAbcHandler> logger,
        IMockRepository mockRepository
    ) 
    {
        _mockRepository = mockRepository;
        _logger = logger;
    }

    public async Task<GetAbcResponse> Handle(GetAbcQuery request, CancellationToken cancellationToken)
    {
        var query = _mockRepository.GetMockData();
        
        // query = query.ApplySortCondition(request.Payload.Sorts) as IQueryable<AbcModel>;
                
        return new GetAbcResponse()
        {
            Data = query?.ToList() ?? new List<AbcModel>()
        };
    }
}