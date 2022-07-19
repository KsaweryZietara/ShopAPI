using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ShopAPI.Data;
using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("ShopConnection");

builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<IShopRepo, SqlShopRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.MapPost("api/products", async (IShopRepo repo, IMapper mapper, ProductCreateDto productCreateDto) => {
    var product = mapper.Map<Product>(productCreateDto);

    await repo.CreateProductAsync(product);
    await repo.SaveChangesAsync();

    return Results.Created($"api/products/{product.Id}", product);
});

app.MapPost("api/customers", async (IShopRepo repo, IMapper mapper, CustomerCreateDto customerCreateDto) => {
    var customer = mapper.Map<Customer>(customerCreateDto);

    await repo.CreateCustomerAsync(customer);
    await repo.SaveChangesAsync();

    return Results.Created($"api/customers/{customer.Id}", customer);
});

app.MapPost("api/orders", async (IShopRepo repo, IMapper mapper, OrderCreateDto orderCreateDto) => {
    var order = mapper.Map<Order>(orderCreateDto);

    await repo.CreateOrderAsync(order);
    await repo.SaveChangesAsync();

    return Results.Created($"api/orders/{order.Id}", order);
});

app.Run();

