using EFCoreFinalApp.Data;
using EFCoreFinalApp.Data.EFCoreFinalApp;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>{
    var config = builder.Configuration;
    var connectionString = config.GetConnectionString("database");
    options.UseSqlite(connectionString);
});
 
builder.Services.AddIdentity<Candidates, IdentityRole>().AddEntityFrameworkStores<DataContext>()
        .AddDefaultTokenProviders();

 builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
     options.LoginPath = "/Candidates/Login";
     options.LogoutPath = "/Candidates/Logout";
     options.AccessDeniedPath = "/Account/AccessDenied";
     options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
 });

builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("CompanyPolicy", policy => policy.RequireRole("company"));
        options.AddPolicy("CandidatePolicy", policy => policy.RequireRole("candidate"));
    });

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

SeedData.TestVerileriniDoldur(app);

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
