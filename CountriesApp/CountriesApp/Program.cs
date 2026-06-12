    using System.Net;

    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    var countries = new Dictionary<int, string>()
    {
        {1,"United States" },
        {2,"Canada" },
        {3,"United Kingdom" },
        {4,"India" },
        {5,"Japan" }
    };

    app.UseRouting();

    app.MapGet("countries", async (context) =>
    {
        string result = string.Join("\n", countries.Select(c => $"{c.Key}, {c.Value}"));
        context.Response.StatusCode = 200;
        await context.Response.WriteAsync(result);
    });

    app.MapGet("countries/{countryId:int}", async (context) =>
    {
        int countryId= int.Parse(context.Request.RouteValues["countryID"]!.ToString()!);

        if (countryId > 100)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
            return;
        }

        if (!countries.ContainsKey(countryId))
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]");
            return;
        }
        await context.Response.WriteAsync(countries[countryId]);

    });

    app.Run();
