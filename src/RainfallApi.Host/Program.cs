using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

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

var app = builder.Build();


app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
