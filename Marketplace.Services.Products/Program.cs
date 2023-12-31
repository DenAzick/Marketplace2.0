using Marketplace.Services.Products.Managers;
using Marketplace.Services.Products.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ProductManager>();
builder.Services.AddScoped<CategoryManager>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(cors =>
{
    cors.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.UseStaticFiles();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
