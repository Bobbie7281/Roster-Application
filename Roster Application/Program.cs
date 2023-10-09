using Microsoft.EntityFrameworkCore;
using Roster_Application.Data;
using Roster_Application.Models;
using Roster_Application.Models.Models_Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddTransient<ICategoryModel, CategoryModel>();
builder.Services.AddTransient<IClientModel, ClientModel>();
builder.Services.AddTransient<IEmployeeModel, EmployeeModel>();
builder.Services.AddTransient<IScheduleModel, ScheduleModel>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
