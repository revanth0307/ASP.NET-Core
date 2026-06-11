var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//ex:files/sample.txt
app.Map("files/{filename}.{extension}",async (context) =>
{   
    // to read and display the values of filename and extenion
    
    string?filename=Convert.ToString(context.Request.RouteValues["filename"]);
    string? extension = Convert.ToString(context.Request.RouteValues["extension"]);

    await context.Response.WriteAsync($"In files - {filename}.{extension}");
    //output: after manually entering the url /http://localhost:5256/files/sample.txt
    //In files - sample.txt
});

//ex:employee/profile/revanth

app.Map("employee/profile/{empName}", async (context) =>
{
    string? empName=Convert.ToString(context.Request.RouteValues["empName"]);
    context.Response.WriteAsync($"In employee profile - {empName}");
});

//ex: product/details/{id}
//if no id passed then it should take def value i/e: {param}=value

app.Map("products/details/{id=1}", async (context) =>
{
int id=Convert.ToInt32(context.Request.RouteValues["id"]);
    await context.Response.WriteAsync($"is in - Product/details/{id}");

});


//route constraints

//eg: dailyreport/{reportdate}:constraint

app.Map("daily-report/{reportdate:datetime}", async (context) =>
{
    DateTime reportdate=Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
    await context.Response.WriteAsync($"daily report -{reportdate}");
});
//enter in url daily-report/2026-06-01

//output :daily report -6/1/2026 12:00:00 AM


//eg:cities/{cityid:guide}
app.Map("cities/{cityid:guid}", async(context) =>
{
   Guid cityid= Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]));
    await context.Response.WriteAsync($"cities id is: {cityid}");

});

//minlength(value),maxlength(value),length(min,max) -- route constraint

app.MapFallback(async (context) =>
{
    await context.Response.WriteAsync($"reqest received at {context.Request.Path}");
});
app.Run();
