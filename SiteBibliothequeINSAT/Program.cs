using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme; ;
options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme; ;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
options.AccessDeniedPath = new PathString("/StudentAccount/Login");
    options.LoginPath = new PathString("/StudentAccount/Login");
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Books}/{id?}");
app.MapControllerRoute(
    name: "Booking",
    pattern: "{controller}/{action}/{studentId}/{BookId}"
);
app.Run();
