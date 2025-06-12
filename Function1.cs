using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace MyFirstFunction;

public class Function1
// In develop and the comment is not in master branch
/// <summary>
/// Represents an Azure Function that handles HTTP GET and POST requests.
/// </summary>
/// <remarks>
/// This class demonstrates a simple Azure Function implementation using dependency injection for logging.
/// </remarks>
/// <param name="logger">
/// The <see cref="ILogger{Function1}"/> instance used for logging information and diagnostics.
/// </param>
/// <developer>
/// Developer Notes:
/// - The function is triggered by HTTP requests with either GET or POST methods.
/// - Logging is performed at the start of each function invocation.
/// - The function returns a welcome message as an <see cref="OkObjectResult"/>.
/// </developer>
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("Function1")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}