using Microsoft.Extensions.Primitives;
using System.IO;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (HttpContext context) =>
{
    StreamReader reader= new StreamReader(context.Request.Body);
    string body= await reader.ReadToEndAsync();
   Dictionary<string,StringValues> queryDic= Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);
    if (queryDic.ContainsKey("firstName"))
    {
        string firstName = queryDic["firstName"][0];
        await context.Response.WriteAsync(firstName);
    }
});

app.Run();
