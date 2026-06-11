var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("map1", async(context) =>
{
   await context.Response.WriteAsync("in map1");
});
app.MapPost("map2", async (context) =>
{
    await context.Response.WriteAsync("in map2");
});

// if we return upto this then after runing the code by def: HTTP ERROR 404 in web browser
//becauae not defined any specific output if incoming URL is not map1 and map2

//When you run your application and open the browser, the default URL requested 
//is the root page:http://localhost:5000/ (path is /).

//The request enters the pipeline.
//It checks app.Map("map1"). Since / is not /map1, it does not match. The request moves past this check.
//It checks app.Map("map2"). Since / is not /map2, it does not match. The request moves past this check.
//The request has now traveled to the very end of the main pipeline.
//Because there is no default middleware configured in the main pipeline to handle it, the ASP.NET Core framework assumes the requested page does not exist and automatically returns an HTTP 404 Not Found error.

//so manually enter in the url after port number /map1 it prints in map1

//use mapfallback if it is nether map1 or map2
app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync($"request recevived at {context.Request.Path}");
});
//output will be "request recevived at /"

app.Run();
