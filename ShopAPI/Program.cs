using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using ShopAPI.Data;
using AutoMapper;
using ShopAPI.Dtos;
using ShopAPI.Models;
using FluentValidation;
using ShopAPI.Validators;
using System.ComponentModel.DataAnnotations;
using FluentValidation.AspNetCore;
using FluentValidation.Results;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("ShopConnection");

builder.Services.AddDbContext<ShopDbContext>(opt => opt.UseSqlServer(sqlConBuilder.ConnectionString));

builder.Services.AddScoped<IShopRepo, SqlShopRepo>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
builder.Services.AddScoped<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
builder.Services.AddScoped<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();

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

app.MapPost("api/products", async (IShopRepo repo, IMapper mapper, ProductCreateDto productCreateDto, IValidator<ProductCreateDto> validator) => {
    var result = await validator.ValidateAsync(productCreateDto);
    
    if(!result.IsValid){
      return Results.BadRequest(result.Errors);
    }
    
    var product = mapper.Map<Product>(productCreateDto);

    await repo.CreateProductAsync(product);
    await repo.SaveChangesAsync();

    return Results.Created($"api/products/{product.Id}", product);
});

app.MapPost("api/customers", async (IShopRepo repo, IMapper mapper, CustomerCreateDto customerCreateDto, IValidator<CustomerCreateDto> validator) => {
    var result = await validator.ValidateAsync(customerCreateDto);
    
    if(!result.IsValid){
      return Results.BadRequest(result.Errors);
    }

    var customer = mapper.Map<Customer>(customerCreateDto);

    await repo.CreateCustomerAsync(customer);
    await repo.SaveChangesAsync();

    return Results.Created($"api/customers/{customer.Id}", customer);
});

app.MapPost("api/orders", async (IShopRepo repo, IMapper mapper, OrderCreateDto orderCreateDto, IValidator<OrderCreateDto> validator) => {
    var result = await validator.ValidateAsync(orderCreateDto);
    
    if(!result.IsValid){
      return Results.BadRequest(result.Errors);
    }
    
    var order = mapper.Map<Order>(orderCreateDto);

    await repo.CreateOrderAsync(order);
    await repo.SaveChangesAsync();

    return Results.Created($"api/orders/{order.Id}", order);
});

app.Run();

