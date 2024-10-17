using MediatR;

namespace DynamicSortingImpl.Abstraction;

public abstract class ListQueryHandler<TRequest, TResponse, TData> : IListQueryHandler<TRequest, TResponse, TData>
    where TRequest : IRequest<TResponse> 
    where TResponse : ListResponseModel<TData>
{
    public IListQueryHandler<TRequest, TResponse, TData> ThisInstance { private get; set; }

    protected ListQueryHandler()
    {
        ThisInstance = this;
    }
    
    public IQueryable<TData> GetQuery(params object?[] args)
    {
        args ??= new object?[] { null };
        return ThisInstance.SetUpQuery(args);
    }
    
    public abstract IQueryable<TData> SetUpQuery(object?[] args);
    
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}