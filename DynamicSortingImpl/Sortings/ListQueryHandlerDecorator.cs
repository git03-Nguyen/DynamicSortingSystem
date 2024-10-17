using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.Sortings.LinqExtensions;
using MediatR;

namespace DynamicSortingImpl.Sortings;

public class ListQueryHandlerDecorator<TRequest, TResponse, TData> : ListQueryHandler<TRequest, TResponse, TData>
    where TRequest : IRequest<TResponse>
    where TResponse : ListResponseModel<TData>
{
    private readonly IListQueryHandler<TRequest, TResponse, TData> _handler;
    private TRequest? _request;
    
    public ListQueryHandlerDecorator(IListQueryHandler<TRequest, TResponse, TData> handler)
    {
        _handler = handler;
    }
    
    public override async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        _handler.ThisInstance = this;
        _request = request;
        return await _handler.Handle(request, cancellationToken);
    }

    public override IQueryable<TData> SetUpQuery(params object?[] parameters)
    {
        var query = _handler.SetUpQuery(parameters);
        var requestType = _request?.GetType();
        var payload = requestType?.GetProperty("Payload")?.GetValue(_request) as ListRequestModel<TData>;
        
        if (payload == null)
        {
            return query;
        }
        
        // Handle sorting
        var sortCondition = payload?.Sorts;
        if (sortCondition != null)
        {
            query = query.ApplySortCondition(sortCondition);
        }
        
        // Handle filtering
        // ...
        
        // Handle paging
        // ...
        
        return query;
    }
}