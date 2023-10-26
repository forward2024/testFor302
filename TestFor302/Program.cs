global using TestFor302.Models;
global using Microsoft.EntityFrameworkCore;
using TestFor302.Data;
using TestFor302.Service.ProductService;
using TestFor302.Service.ClientService;
using TestFor302.Service.OrderService;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IProduct, ServiceProduct>();
builder.Services.AddScoped<IClient, ServiceClient>();
builder.Services.AddScoped<IOrder, ServiceOrder>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
