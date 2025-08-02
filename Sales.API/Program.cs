using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sales.Application.Mappings;
using Sales.Application.Services;
using Sales.Domain.Interfaces;
using Sales.Infrastructure.Data;
using Sales.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ILoggerFactory loggerFactory = LoggerFactory.Create(logging => logging.AddConsole());

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDBConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IShipperService, ShipperService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// AutoMapper configuration
MapperConfigurationExpression mapperConfigExpression = new();
mapperConfigExpression.AddProfile(new CategoryProfile());
mapperConfigExpression.AddProfile(new CustomerProfile());
mapperConfigExpression.AddProfile(new EmployeeProfile());
mapperConfigExpression.AddProfile(new OrderDetailProfile());
mapperConfigExpression.AddProfile(new OrderProfile());
mapperConfigExpression.AddProfile(new ProductProfile());
mapperConfigExpression.AddProfile(new ShipperProfile());
mapperConfigExpression.AddProfile(new SupplierProfile());
MapperConfiguration mapperConfig = new(mapperConfigExpression, loggerFactory);
IMapper mapper = new Mapper(mapperConfig);

builder.Services.AddSingleton(mapper);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sales API",
        Version = "v1"
    });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
