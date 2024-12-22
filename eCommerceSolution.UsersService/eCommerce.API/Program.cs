using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure services
builder.Services.AddInfrastructure();

// Add core services
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers();

// Build the web application
var app = builder.Build();

// Enable routing
app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Mapping controller routes on web API
app.MapControllers();

app.Run();
