using DeckService;
using DeckService.Setup;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var app = builder.Build();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint($"/swagger/{ApiInformation.RouteVersion}/swagger.json", ApiInformation.RouteVersion);
    options.RoutePrefix = string.Empty;
});
app.UseSwagger();
app.UseRouting();
app.MapControllers();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.Run("http://localhost:3000");


//todo: add a test for the deck generator service
//todo: add a test for the deck repository
//todo: add a test for the deck handlers
//todo add logging