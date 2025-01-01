using LibraryMAngeSystem.Models;
using LibraryMAngeSystem.Models.rop;
using LibraryMAngeSystem.Models.rop.internalinterface;
using LibraryMAngeSystem.Models.rop.ropistary;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<appdbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("mo")));
builder.Services.AddScoped<IBook,rBook>();
builder.Services.AddScoped<IMember,rMember>();
builder.Services.AddScoped<IBorrowRecord,rBorrowRecord>();

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
