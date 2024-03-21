using Hamburger_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
	[Authorize(Policy = "AdminOnly")]
	[Area("AdminPanel")]
	public class PanelController : Controller
	{
		private readonly UserManager<User> _userManager;
		public PanelController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}
	

	

		public IActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> AdminOlustur()
		{
			User user = new User()
			{
				Ad = "admin",
				Soyad = "1",
				Email = "admin1@hamburger.com",
				UserName = "admin1@hamburger.com"
			};
			await _userManager.CreateAsync(user, "123");
			await _userManager.AddToRoleAsync(user, "Admin");
			return Content("Admin olustu..");

		}
	}
}
