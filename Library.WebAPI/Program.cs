using Library.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

await app.UseMiddlewares();

app.Run();
