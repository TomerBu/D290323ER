using Microsoft.AspNetCore.Mvc;

namespace Lec1.Controllers
{
	public class AboutController(ILogger<AboutController> logger) : Controller
	{
		public IActionResult Index(int? id)
		{
			logger.LogInformation(id is null ? "No id" : $"id: {id}");
			return View();
		}

		//    localhost:3333/About/Social
		public IActionResult Social()
		{
			return View();
		}
	}
}
