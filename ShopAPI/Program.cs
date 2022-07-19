using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ShopAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("ShopConnection");

builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<IShopRepo, SqlShopRepo>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/customers", async (IShopRepo repo) => {
    return Results.Ok(await repo.GetAllCustomersAsync());
});

app.MapGet("api/orders", async (IShopRepo repo) => {
    return Results.Ok(await repo.GetAllOrdersAsync());
});

app.MapGet("api/products", async (IShopRepo repo) => {
    return Results.Ok(await repo.GetAllProductsAsync());
});



app.Run();

