// var app1 = WebApplication.CreateBuilder(args).Build().Run();

using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Context.Models.Configurations;
using WebApplication2.DataAccess;
using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Services.AddSingleton<IFileContextOptions<IFileContext>>();
builder.Services.AddScoped<IDataContext, AppFileContext>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); // linked to Swagger;
builder.Services.AddSwaggerGen();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

await app.RunAsync();