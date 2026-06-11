namespace CustomMiddleware.CustomMiddleWare
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("my custom middleware - starts");
            await next(context);
            await context.Response.WriteAsync("my custom middleware - Ends");

        }


    }
}
