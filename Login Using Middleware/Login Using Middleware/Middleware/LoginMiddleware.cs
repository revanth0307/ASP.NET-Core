using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Login_Using_Middleware.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "POST" && context.Request.Path == "/")
            {
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                var params_ = System.Web.HttpUtility.ParseQueryString(body);

                string? email = params_["email"];
                string? password = params_["password"];

                List<string> errors = new List<string>();

                if (string.IsNullOrEmpty(email))
                    errors.Add("Invalid input for 'email'");

                if (string.IsNullOrEmpty(password))
                    errors.Add("Invalid input for 'password'");

                if (errors.Count > 0)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync(string.Join("\n", errors));
                    return;
                }

                if (email == "admin@example.com" && password == "admin1234")
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Successful login");
                }
                else
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login");
                }
                return;
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LoginMiddlewareExtensions
    {
        public static IApplicationBuilder UseLoginMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoginMiddleware>();
        }
    }
}
