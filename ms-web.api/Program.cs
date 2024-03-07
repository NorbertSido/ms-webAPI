using ms_web.api.Dtos;
using ms_web.api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapProductsEndproints();

app.Run();
