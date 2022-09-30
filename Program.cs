using InventoryAPI;
using InventoryAPI.Models;
using InventoryAPI.Services;
using InventoryAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IPartService, PartService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);


var dbAssemblyName = typeof(Program).Namespace;


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MSSQLConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly(dbAssemblyName)
    )
);

var identityBuilder = builder.Services.AddIdentityCore<AppIdentityUser>(o =>
{
    o.Password.RequiredLength = 8;
    o.User = new UserOptions { RequireUniqueEmail = true };
});

identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(IdentityRole), identityBuilder.Services);
identityBuilder.AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
