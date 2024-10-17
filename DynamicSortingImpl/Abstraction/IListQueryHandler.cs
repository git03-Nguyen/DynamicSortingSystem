using MediatR;

namespace DynamicSortingImpl.Abstraction;

public interface IListQueryHandler<TRequest, TResponse, TData> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse> 
    where TResponse : ListResponseModel<TData>
{
    IListQueryHandler<TRequest, TResponse, TData> ThisInstance { set; }
    IQueryable<TData> GetQuery(params object?[] args);
    IQueryable<TData> SetUpQuery(params object?[] args);
}