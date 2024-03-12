using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Registration_Form.Data;
using Registration_Form.Ioc.Repository;
using Registration_Form.Ioc.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region context
builder.Services.AddDbContext<UserContext>(Option =>
{
    Option.UseSqlServer("Data Source =.; Initial Catalog = RegistrationForm_DB; Integrated Security = true");
});
#endregion

#region Ioc
builder.Services.AddScoped<IUserRepository, UserRepository>();
#endregion

#region Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Login/Login";
    option.LogoutPath = "/Login/Logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(10);
});
#endregion

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
