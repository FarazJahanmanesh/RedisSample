using Microsoft.Extensions.Caching.Memory;
using Sample.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = builder.Configuration.GetSection("RedisConnectionSettings")["ConnectionString"];
    option.InstanceName = builder.Configuration.GetSection("RedisConnectionSettings")["InstanceName"];
});

builder.Services.Configure<MemoryCacheEntryOptions>(options =>
{
    options.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
});
builder.Services.AddScoped<ICaptchaRepository, CaptchaRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
