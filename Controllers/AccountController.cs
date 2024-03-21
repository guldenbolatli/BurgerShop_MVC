using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Hamburger_MVC.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AccessDenied(string returnUrl)
		{
			returnUrl = returnUrl is NullLogger ? "/Home/Index" : returnUrl;
			return View();
		}
	}
}
