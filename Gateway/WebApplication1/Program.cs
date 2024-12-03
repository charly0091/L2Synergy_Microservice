using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile("ocelot.json", true, true);
builder.Services.AddCors(opt => opt.AddPolicy("Policy", policy =>
{
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
    policy.WithOrigins("http://localhost:5104");
    policy.AllowCredentials();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("Policy");

app.UseAuthorization();

app.UseOcelot().Wait();

app.Run();
