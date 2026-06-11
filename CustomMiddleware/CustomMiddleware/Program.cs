

using CustomMiddleware.CustomMiddleWare;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient< MyCustomMiddleware>();
var app = builder.Build();

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("from middleware 1");
    await next(context);
});
//midleware 2
app.UseMiddleware<MyCustomMiddleware>();

//midleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("from middle ware 3");
    //so now the context can pass to next delegate
});

app.Run();