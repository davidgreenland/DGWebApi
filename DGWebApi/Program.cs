using DGWebApi.Services;
using DGWebApi.Services.Interfaces;
using Polly;
using Polly.Extensions.Http;
using System.Net;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);
var httpRetryPolicy = HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
        .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("issHttpClient", x => x.BaseAddress = new Uri("https://api.wheretheiss.at/v1/"));
builder.Services.AddTransient<ISatelliteService, SatelliteService>();
builder.Services.AddHttpClient("agifyClient", x => x.BaseAddress = new Uri("https://api.agify.io/"));
builder.Services.AddTransient<IAgifyService, AgifyService>();
builder.Services.AddSingleton<IAsyncPolicy<HttpResponseMessage>>(httpRetryPolicy);
builder.Services.Configure<JsonSerializerOptions>(options =>
{
    options.PropertyNameCaseInsensitive = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
