using DontFlipIt.Context;
using DontFlipIt.Models;
using DontFlipIt.Repository;
using DontFlipIt.Repository.IRepository;
using DontFlipIt.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging();
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelDbContext")));
builder.Services.AddIdentity<HotelUserEntity, IdentityRole>()
    .AddEntityFrameworkStores<HotelContext>()
    .AddDefaultTokenProviders();

    
// signinmanagers cookie settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;  // Protect the cookie from being accessed via JavaScript
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;  // Only send the cookie over HTTPS
    options.ExpireTimeSpan = TimeSpan.FromDays(2);  // Set the expiration time for the cookie
    options.Cookie.SameSite = SameSiteMode.Strict;

});

// Session settings
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<GuestRepository>();
builder.Services.AddScoped<RoomRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<Logger<AuthenticationService>>();
builder.Services.AddLogging(opt => opt.AddConsole());
builder.Services.AddScoped<UnitOfWork>();




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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
