using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.Sortings.Models;
using FluentValidation;
using MediatR;

namespace DynamicSortingImpl.Middlewares;

public class SortPipelineBehavior<TRequest, TResponse, TData> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ListResponseModel<TData>
{
    public SortPipelineBehavior()
    {
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // try
        // Type type = request.Payload.Sorts[0].Field.GetType().GetCustomAttributes(AllowSort)
        // type is 

        var type = request.GetType();
        var payload = type.GetProperty("Payload")?.GetValue(request) as ListRequestModel<TData>;
        
        Console.WriteLine($"[SortPipelineBehavior]: {request.GetType().Name}"); 
        
        return await next();
    }
}