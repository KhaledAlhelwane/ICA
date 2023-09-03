using ICA.Data;
using ICA.Models;
using ICA.Models.Repository;
using ICA.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//Identity Configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICRUD<Article>, ArticleRepository>();
builder.Services.AddScoped<ICRUD<Album>, AlbumRepository>();
builder.Services.AddScoped<ICRUD<ITRequist>, ItRequistRepository>();

builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailingService, MailingService>();

//localiztion Configuration
builder.Services.AddLocalization(Options=>Options.ResourcesPath= "Resources");
builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

//set the session to be unlimited 
builder.Services.ConfigureApplicationCookie(Options =>
{
    Options.Cookie.Name = "AspNetCore.Identity.Application";
    Options.ExpireTimeSpan = TimeSpan.FromDays(365 * 100);
    Options.SlidingExpiration = true;
});





builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
            var supportedCultures = new[]
            {
                    new CultureInfo("en"),
                    new CultureInfo("ar-SY")
                };

            options.DefaultRequestCulture = new RequestCulture(culture: "ar-SY", uiCulture: "ar-SY");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });


builder.Services.AddControllersWithViews();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.UseRequestLocalization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "article",
         //pattern: "article/{title}",
         pattern: "article/{title}",
        defaults: new { controller = "Home", action = "article" });
    endpoints.MapControllerRoute(
       name: "section",
       pattern: "section/{AssosiationURL}",
       defaults: new { controller = "sections", action = "section" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapRazorPages();

app.Run();
