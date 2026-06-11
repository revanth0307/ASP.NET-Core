var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
   string?firstNumber= context.Request.Query["firstNumber"];
   string? secondNumber = context.Request.Query["secondNumber"];
    string? operation = context.Request.Query["operation"];

    List<string> errors = new List<string>();

    if (string.IsNullOrEmpty(firstNumber))
    {
        errors.Add("Invalid input for 'firstNumber'");
    }
    if(string.IsNullOrEmpty(secondNumber))
    {
        errors.Add("Invalid input for 'secondNumber'");
    }
    if (string.IsNullOrEmpty(operation))
    {
        errors.Add("Invalid input for 'operation'");
    }

    if (errors.Count > 0)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(string.Join("\n", errors));
        return;
    }
    bool isFirstNumberValid = int.TryParse(firstNumber, out int firstNum);
    bool isSecondNumberValid = int.TryParse(secondNumber, out int secondNum);
    if (!isFirstNumberValid)
    {
        errors.Add("Invalid input for 'firstNumber'");
    }
    if (!isSecondNumberValid)
    {
        errors.Add("Invalid input for 'secondNumber'");
    }

    if (errors.Count > 0)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync(string.Join("\n", errors));
        return;
    }

    int result = 0;
    switch (operation)
    {
        case "add":
            result = firstNum + secondNum;
            break;
        case "subtract":
            result=firstNum-secondNum;
            break;
        case "multiply":
            result = firstNum * secondNum;
            break;
        case "divide":
            result = firstNum / secondNum;
            break;
        case "remainder":
            result = firstNum % secondNum;
            break;
        default:
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid input for 'operation'");
            return;


    }
    await context.Response.WriteAsync(result.ToString());
});

app.Run();
