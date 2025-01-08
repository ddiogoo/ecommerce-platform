using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var mappers = new[]
{
    typeof(ApplicationUserMappingProfile).Assembly,
    typeof(RegisterRequestMappingProfile).Assembly
};
builder.Services.AddAutoMapper(mappers);
builder.Services.AddFluentValidationAutoValidation();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
