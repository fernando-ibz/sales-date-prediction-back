using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Sales.Application.Mappings;
using Sales.Application.Services;
using Sales.Domain.Interfaces;
using Sales.Infrastructure.Data;
using Sales.Infrastructure.Repositories;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
ILoggerFactory loggerFactory = LoggerFactory.Create(logging => logging.AddConsole());

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StoreDBConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSProdPolicy", policy =>
    {
        policy
        .SetIsOriginAllowed(origin =>
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                Console.WriteLine($"CORS Production Policy. Origin is empty.");
                return false;
            }

            string host = new Uri(origin).Host.ToLowerInvariant();
            bool isProduction = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";

            if (host.EndsWith(builder.Configuration.GetValue<string>("ProdAllowedHost")!, StringComparison.OrdinalIgnoreCase))
                return true;

            Console.WriteLine($"CORS ProductionPolicy. Origin: {origin} is not allowed.");
            return false;
        })
        .AllowAnyMethod()
        .AllowCredentials()
        .AllowAnyHeader();
    });

    options.AddPolicy("CORSDevPolicy", policy =>
    {
        policy
        .SetIsOriginAllowed(origin =>
        {
            if (string.IsNullOrWhiteSpace(origin)) return false;

            string host = new Uri(origin).Host.ToLowerInvariant();

            if (new Uri(origin).Host != "localhost")
            {
                Console.WriteLine($"CORS Developer Policy. Origin: {origin} is not allowed.");
                return false;
            }

            return true;
        })
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

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
        Title = "Sales Date Prediction API",
        Version = "v1"
    });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales Date Prediction v1");
    });
}

app.UseCors(app.Environment.IsDevelopment()
    ? "CORSDevPolicy"
    : "CORSProdPolicy");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
