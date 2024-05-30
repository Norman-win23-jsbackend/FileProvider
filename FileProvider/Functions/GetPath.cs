using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FileProvider.Functions;

public class GetPath(ILogger<GetPath> logger)
{
    private readonly ILogger<GetPath> _logger = logger;



    [Function("GetPath")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");

        string path = req.Query["path"];

        if (string.IsNullOrEmpty(path))
        {
            _logger.LogWarning("Path is not provided.");
            return new BadRequestObjectResult("Please provide a path in the query parameter.");
        }

        return new OkObjectResult($"Requested path: {path}");
    }
}
