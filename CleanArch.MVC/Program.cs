using Microsoft.EntityFrameworkCore.Design;
using CleanArch.Infra.Ioc;
using CleanArch.MVC.MappingConfig;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

    var builder = WebApplication.CreateBuilder(args);




    // Add services to the container.
    //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    //builder.Services.AddDbContext<ApplicationDbContext>(options =>
    //    options.UseSqlServer(connectionString));

    //builder.Services.AddDefaultIdentity<IdentityUser>()
    //    .AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    builder.Services.AddAutoMapperConfiguration();

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

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

 builder = WebApplication.CreateBuilder(args);

var defaultCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

app.UseRequestLocalization(localizationOptions);

app.Run();
