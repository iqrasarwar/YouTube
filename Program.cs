using YouTube.Models;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Getting Connection string
string connString = builder.Configuration.GetConnectionString("DefaultConnection");
//Getting Assembly Name
var migrationAssembly = typeof(Program).Assembly.GetName().Name;

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(connString, sql => sql.MigrationsAssembly(migrationAssembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddSingleton(new YouTubeService(new BaseClientService.Initializer()
{
   ApiKey = "AIzaSyBd9CcBA18DsoJZfO75tlMHOp2lxdSAdsY",
   ApplicationName = "YouTubeClone"
}));

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
    pattern: "{controller=Home}/{action=Index}/{id?}",
    app.MapRazorPages());

app.Run();
