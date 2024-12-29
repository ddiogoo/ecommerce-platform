using System.Reflection;
using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services
builder.Services.AddInfrastructure();

// Add core services
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Add mappers profile
var mappers = new[]
{
    typeof(ApplicationUserMappingProfile).Assembly,
    typeof(RegisterRequestMappingProfile).Assembly
};
builder.Services.AddAutoMapper(mappers);

// Build the web application
var app = builder.Build();

// Enable middlewares
app.UseExceptionHandlingMiddleware();

// Enable routing
app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Mapping controller routes on web API
app.MapControllers();

app.Run();
