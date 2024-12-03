using Autofac.Extensions.DependencyInjection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPI;
using System.Text.Json.Serialization;
using Infrastructure.Helpers;
using Application;
using Application.Aggregates.CryptoCurrencies.Queries;
using MediatR.Extensions.Autofac.DependencyInjection;
using Infrastructure.Services;
using Infrastructure.Strategies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddApiVersioning(options => options.ReportApiVersions = true);
builder.Services.AddHttpCacheHeaders();
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var validationProblemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Type = "",
                Title = "",
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = "",
                Instance = context.HttpContext.Request.Path
            };

            validationProblemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

            return new UnprocessableEntityObjectResult(validationProblemDetails);
        };
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(container =>
    {
        var infrastructureAssembly = typeof(ThirdPartyConstant).Assembly;
        var applicationAssembly = typeof(BaseCollectionResult<>).Assembly;

        var configuration = MediatRConfigurationBuilder
                .Create(applicationAssembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

        container.RegisterMediatR(configuration);

        container.RegisterAssemblyTypes(infrastructureAssembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();


        container.RegisterAssemblyTypes(typeof(CryptoCurrencyQueryResult).Assembly)
                .AssignableTo(typeof(CryptoCurrencyQueryResult))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
    });

builder.Services.AddTransient<IStrategy, CoinMarketCapStrategy>();
builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Okala Rest API", Version = "v1" });
});

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Okala Rest API v1"));
}

app.UseHttpCacheHeaders();
app.UseRouting();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//app.UseAuthorization();

app.Run();
