using PlacementPortal.Application;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
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
    //pattern: "{controller=Authentication}/{action=LogIn}/{id?}");
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    // pattern: "{controller=Student}/{action=AddStudent}/{id?}");
    pattern: "{controller=CompanyRequest}/{action=CompanyRequest}/{id?}");
    //pattern: "{controller=Student}/{action=AddStudent}/{id?}");
    //pattern: "{controller=College}/{action=College}/{id?}");
app.Run();