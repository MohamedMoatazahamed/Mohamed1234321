using Microsoft.EntityFrameworkCore;
using Task_Management.Models;
using Task_Management.Models.repo.internalinterface;
using Task_Management.Models.repo.reposatry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<appdbcontext>(option=>option.UseSqlServer(builder.Configuration.GetConnectionString("MO")));
builder.Services.AddScoped<IUser,rUser>();
builder.Services.AddScoped<ITask, rTask>();
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
