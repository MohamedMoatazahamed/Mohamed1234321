using Microsoft.EntityFrameworkCore;
using schoolsystem.Models;
using schoolsystem.Models.repos.internalinterface;
using schoolsystem.Models.repos.rop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<appdbcontext>(options =>  options.UseSqlServer(builder.Configuration.GetConnectionString("first")));
builder.Services.AddScoped<IStudent,rstudent>();
builder.Services.AddScoped<Iteather,rteather>();
builder.Services.AddScoped<Iclass,rClass>();
builder.Services.AddScoped<IEnrollment, rEnrollment>();



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
