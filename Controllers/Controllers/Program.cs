using ControllersExample.Controllers;
var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<HomeController>();
//we can add this way but instead of adding each controller manualyyy we can direct add all controllers by:
builder.Services.AddControllers();// it will collect all controler which has suffixed 'Controller'
//before build method we need to add service classes(reusable class)
var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
