using System.Reflection;
using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.Entities;
using DynamicSortingImpl.FeatureQueries.Test;
using DynamicSortingImpl.FeatureQueries.Test.RequestResponse;
using DynamicSortingImpl.Middlewares;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicSortingImpl.Sortings.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection RegisterSortPipelineBehaviors(this IServiceCollection services)
    {
        var allTypes = Assembly.GetExecutingAssembly().GetTypes();
        var requestTypes = allTypes
            .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>)))
            .ToList();

        foreach (var requestType in requestTypes)
        {
            var responseType = requestType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequest<>))
                .GetGenericArguments()[0];

            var responseAbstract = responseType.BaseType;
            if (responseAbstract is not { IsGenericType: true } || responseAbstract.GetGenericTypeDefinition() != typeof(ListResponseModel<>))
            {
                continue;
            }
            
            var dataType = responseAbstract.GetGenericArguments()[0];
            
            // Register SortPipelineBehavior<TRequest, TResponse, TData> dynamically
            var behaviorType = typeof(SortPipelineBehavior<,,>).MakeGenericType(requestType, responseType, dataType);
            var pipelineBehaviorType = typeof(IPipelineBehavior<,>).MakeGenericType(requestType, responseType);

            services.AddScoped(pipelineBehaviorType, behaviorType);
        }
        
        return services;
    }
    
    public static IServiceCollection RegisterListHandlerDecorator(this IServiceCollection services)
    {
        // Register all concrete classes implementing IListQueryHandler as IListQueryHandlers.
        services.Scan(x => x.FromAssembliesOf(typeof(IListQueryHandler<,,>))
            .AddClasses(classes => classes.AssignableTo(typeof(IListQueryHandler<,,>))
                .Where(t => !t.IsGenericType))
            .AsImplementedInterfaces(t => t.IsGenericType
                                          && t.GetGenericTypeDefinition() == typeof(IListQueryHandler<,,>))
            .WithTransientLifetime());

        // Decorate registered IListQueryHandlers with open generic decorator.
        services.Decorate(typeof(IListQueryHandler<,,>), typeof(ListQueryHandlerDecorator<,,>));

        // Get registered IListQueryHandlers service descriptors from the container.
        var registeredQueryHandlers = services
            .Where(x => x.ServiceType.IsGenericType
                        && x.ServiceType.GetGenericTypeDefinition() == typeof(IListQueryHandler<,,>))
            .ToArray();

        foreach(var serviceDescriptor in registeredQueryHandlers)
        {
            // Find the IRequestHandler type of registered IListQueryHandler.
            var requestHandlerType = serviceDescriptor.ServiceType.GetInterfaces()
                .First(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));
    
            // Register a decorated IListQueryHandler to be returned for IRequestHandler.
            services.Add(new ServiceDescriptor(requestHandlerType,
                sp => sp.GetRequiredService(serviceDescriptor.ServiceType), serviceDescriptor.Lifetime));
        }

        // Finally, register MediatR.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    } 
}