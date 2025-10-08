using BOOTSHOP.Models.Data.BOOTSHOPContext;
using BOOTSHOP.Models.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering the DbContext with a connection string
builder.Services.AddDbContext<BootshopContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("BootshopConnection"));
});

//Registering SERVICE
builder.Services.AddScoped<ProductCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
