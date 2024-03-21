using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ContextDB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));
builder.Services.AddControllers().AddNewtonsoftJson();

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ContextDB>();

builder.Services.AddIdentity<User, Role>(x =>
{
    x.SignIn.RequireConfirmedEmail = false;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequireUppercase = false;
    x.Password.RequiredLength = 3;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireLowercase = false;
}).AddRoles<Role>()
  .AddEntityFrameworkStores<ContextDB>();



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("Admin");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnly", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole("User");
    });
});


//builder.Services.ConfigureApplicationCookie(options =>
//{
//	options.AccessDeniedPath = "/home/Privacy";
//});  Autherizon yanlis ise default account/accessdenied'a yönlendirir ama özelleþtirmek istersek böyle.

builder.Services.AddTransient<IEmailSender, EmailSender>();


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

///////
app.UseAuthentication();
app.UseAuthorization();

//baþlangýç sayfasý ayarlamak için
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area=UserPanel}/{controller=Panel}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});



app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "AdminArea/{controller=Panel}/{action=Index}"
    );
app.MapAreaControllerRoute(
    name: "user",
    areaName: "User",
    pattern: "UserArea/{controller=Panel}/{action=Index}"
    );


app.MapRazorPages();
app.Run();
