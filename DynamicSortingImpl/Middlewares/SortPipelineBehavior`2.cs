using DynamicSortingImpl.Sortings.Models;
using MediatR;

namespace DynamicSortingImpl.Middlewares;

public class SortPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ISortQuery, IRequest<TResponse>
{
    public SortPipelineBehavior()
    {
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        Console.WriteLine($"SortPipelineBehavior: {request.Payload.Sorts}"); 
        
        return await next();
    }
}