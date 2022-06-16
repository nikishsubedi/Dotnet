using Ecommerce;
using Ecommerce.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the IOC container.
builder.Services.AddControllersWithViews();

// Adding Interface to the IOC container
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddDbContext<CommerceDbContext>(op =>
{
    op.UseSqlServer("Data Source = (localdb)\\ProjectModels; Initial Catalog = myDB; Integrated Security = True;");

});

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<CommerceDbContext>();

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
