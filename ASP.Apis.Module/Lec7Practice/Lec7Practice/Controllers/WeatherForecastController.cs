using Lec7Practice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Lec7Practice.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{

	[HttpGet]
	public IActionResult Get()
	{
		//http://127.0.0.1:5173
		//https://192.168.1.2
		//https://myclient.com


		

		//Console.WriteLine("\u001b[31mHello World\u001b[0m");
		Console.WriteLine(Chalk.Red("this is a ").Blue("nice").Green("dog").Yellow("!"));

		logger.Log(LogLevel.Trace, "trace message");
		logger.LogTrace("trace");
		logger.LogDebug("debug");
		logger.LogInformation(
			Chalk.Cyan("Foo").Red("....")
		);
		logger.LogWarning("warning");
		logger.LogError("error");
		logger.LogCritical("critical");


		return Ok(new { message = "cool" });
	}
}