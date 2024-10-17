using System.Reflection;
using DynamicSortingImpl.Abstraction;
using DynamicSortingImpl.FeatureQueries;
using DynamicSortingImpl.FeatureQueries.Test;
using DynamicSortingImpl.Middlewares;
using DynamicSortingImpl.Others;
using DynamicSortingImpl.Sortings.Extensions;
using FluentValidation;
using MediatR;

namespace DynamicSortingImpl;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddScoped<IMockRepository, MockRepository>();
        // builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        builder.Services.RegisterListHandlerDecorator();
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        builder.Services
            .RegisterSortPipelineBehaviors();
                        
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}