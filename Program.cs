using StoreApp.Infrastructe.Extensions;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();//controller olmadan sayfa tasarlama


//myconfigs
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();
builder.Services.ConfigureRouting();



builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();
app.UseStaticFiles();///wwwroot klasörünün kullanılabilir hale gelmesi
app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );


    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapRazorPages();//razor page kaydı
});

app.ConfigureAndCheckMigration();
app.Run();
