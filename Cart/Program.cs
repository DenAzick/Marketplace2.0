using Cart.Services;
using Cart.Providers;
using Marketplace.Common.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();


//object value = builder.Services.AddJwtConfiguration(builder.Configuration);


builder.Services.AddSwaggerGenWithToken();

builder.Services.AddScoped<UserProvider>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICartServices, CartService>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "cache";
    options.InstanceName = "CartInstance";

});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(cors =>
{
    cors.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();