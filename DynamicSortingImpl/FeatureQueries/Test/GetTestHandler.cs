using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.Entities;
using DynamicSortingImpl.FeatureQueries.Test.RequestResponse;
using DynamicSortingImpl.Others;
using DynamicSortingImpl.Sortings.LinqExtensions;

namespace DynamicSortingImpl.FeatureQueries.Test;

public class GetTestHandler : ListQueryHandler<GetTestQuery, GetTestResponse, AbcModel>
{
    private readonly ILogger<GetTestHandler> _logger;
    private readonly IMockRepository _mockRepository;

    public GetTestHandler(
        ILogger<GetTestHandler> logger,
        IMockRepository mockRepository
    ) 
    {
        _mockRepository = mockRepository;
        _logger = logger;
    }

    public override async Task<GetTestResponse> Handle(GetTestQuery request, CancellationToken cancellationToken)
    {
        var currentUserId = _httpContextAccessor.GetCurrentUserId();
        var payload = request.Payload;
        var functionName = $"{nameof(GetAffiliatePartnersF2Handler)} UserId = {currentUserId} =>";
        _logger.LogInformation($"{functionName} Payload = {JsonHelper.Serialize(payload)}");

        var response = new GetAffiliatePartnersF2Response { Status = ResponseStatusCode.BadRequest.ToInt() };
        
        try
        {
            var userAffiliateId = await _unitOfRepository.UserAffiliate
                .Where(uf => uf.UserId == currentUserId && uf.Status == UserAffiliateStatus.ACTIVE && !uf.IsDeleted)
                .AsNoTracking()
                .Select(u => new
                {
                    u.Id,
                })
                .FirstOrDefaultAsync(cancellationToken);
            if (userAffiliateId is null)
            {
                _logger.LogInformation($"{functionName} user have not become AP yet.");
                response.Status = ResponseStatusCode.BadRequest.ToInt();
                response.ErrorMessage = BackOfficeTranslation.AFF_ERR_008.Localize();
                response.ErrorMessageCode = BackOfficeTranslation.AFF_ERR_008.Code();
                return response;
            }
            
            var query = GetQuery(_unitOfRepository, userAffiliateId.Id);
            
            response.Status = ResponseStatusCode.OK.ToInt();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"{functionName} Has error: Error message = {ex.Message}");
            response.Status = ResponseStatusCode.InternalServerError.ToInt();
            response.ErrorMessage = BackOfficeTranslation.EXH_ERR_002.Localize();
            response.ErrorMessageCode = BackOfficeTranslation.EXH_ERR_002.Code();
        }

        return response;
        
        return new GetTestResponse()
        {
            Data = query?.ToList() ?? new List<AbcModel>()
        };
    }

    public override IQueryable<AbcModel> SetUpQuery(object?[] args)
    {
        var repository = args[0] as IUnitOfRepo;
        var id = args[2] as long;
        var query = from uf in _unitOfRepository.UserAffiliate.GetAll()
            join us in _unitOfRepository.UserAffiliateStatistic.GetAll()
                on uf.Id equals us.UserAffiliateId
            join u in _unitOfRepository.User.GetAll()
                on uf.UserId equals u.Index
            where (string.IsNullOrWhiteSpace(payload.Keyword) ||
                   EF.Functions.ILike(u.FirstName.ToFullName(u.LastName), payload.Keyword.ToILikePattern())
                   || EF.Functions.ILike(u.Email, payload.Keyword.ToILikePattern())
                  )
                  && Regex.IsMatch(uf.Path, userAffiliateId.Id.GetAPsPatternByLevel(2))
                  && uf.Status == UserAffiliateStatus.ACTIVE
                  && !uf.IsDeleted 
                          
            select new GetAffiliatePartnersF2Data
            {
                Id = uf.Id,
                FullName = u.FirstName.ToFullName(u.LastName),
                RegistrationDate = uf.RegistrationDate,
                Commission = us.DirectCustomerCommission,
                TotalCustomer = us.TotalDirectCustomer,
                TotalDirectAP = us.TotalApF1,
                RawEmail = u.Email
            };
        return query;
    }
}