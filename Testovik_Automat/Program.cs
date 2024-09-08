using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Testovik_Core.Abstractions;
using Testovik_Core.Services;
using Testovik_Data.Context;
using Testovik_Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
builder.Services.AddDbContext<TestovikContext>(options => options.UseSqlServer(connection));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options => options.LoginPath = "/Home/LoginView");

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

//////////////////////////

builder.Services.AddScoped<IBrendRepository, BrendRepository>();
builder.Services.AddScoped<ICoinRepository, CoinRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderWithUserRepository, OrderWithUserRepository>();
builder.Services.AddScoped<ITovarRepository, TovarRepository>();
builder.Services.AddScoped<IUserRepository , UserRepository>();

builder.Services.AddScoped<IBrendService, BrendService>();
builder.Services.AddScoped<ICoinService, CoinService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderWithUserService, OrderWithUserService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITovarService, TovarService>();

//////////////////////////

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();   
app.UseAuthorization();   

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
