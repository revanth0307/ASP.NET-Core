var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello");
//});

// if we are trying to use multiple run menthods , then only one will exectute not the other
// Only one Run() middleware should be used.Run() is a terminal middleware, meaning it handles the request
// and does not pass control to any subsequent middleware in the pipeline.
// Therefore, if multiple Run() methods are added, the first one that executes
// ends the request, and the later Run() methods will never be reached.

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello again");
//});

//----------------------------------------------------------------------
//therfore instead of using multiple run menthods in midleware , we will use:but with 2 paramaters
//2nd param is RequestDelegate

//middleware 1
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello");
    await next(context);
    //so now the context can pass to next delegate
});
//midleware 2
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Hello again");
    await next(context);
    //so now the context can pass to next delegate
});

//midleware 3
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Hello again");
    //so now the context can pass to next delegate
});

app.Run();