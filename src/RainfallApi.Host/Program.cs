using Microsoft.OpenApi.Models;
using RainfallApi.Application;
using RainfallApi.Domain;
using RainfallApi.Infrastructure;
using RainfallApi.Infrastructure.EnvironmentAgency;
using RainfallApi.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Rainfall Api",
        Description = "An API which provides rainfall reading data",
    });
});

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddDomainServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEnvironmentAgency(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();


app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
