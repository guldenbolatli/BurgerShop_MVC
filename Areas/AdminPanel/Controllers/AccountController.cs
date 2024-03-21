using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
	[Authorize(Policy = "AdminOnly")]
	[Area("AdminPanel")]
	public class AccountController : Controller
	{
		private readonly ContextDB _contextDb;
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;



		public AccountController(ContextDB contextDb, UserManager<User> userManager,RoleManager<Role> roleManager)
		{
			_contextDb = contextDb;
			_userManager = userManager;
			_roleManager= roleManager;
		}

		public IActionResult Listele()
		{
			var usersRoles = new List<UserVM>();
			var users = _userManager.Users.ToList();
			foreach (var item in users)
			{
				var role = _userManager.GetRolesAsync(item).Result.FirstOrDefault();
				var vwModel = new UserVM()
				{
					User = item,
					SelectedRole = role
				};
				usersRoles.Add(vwModel);
			}

			return View(usersRoles);
		}

		public async Task<IActionResult> Update(int id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			var userRole = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
			
			UserVM userVm = new UserVM()
			{
				User = user,
				SelectedRole = userRole,
				Roles = new SelectList(_contextDb.Roles,"Id","Name")
			};
			return View(userVm);
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id,UserVM userVM)
		{
			try
			{
				User user = await _userManager.FindByIdAsync(id.ToString());

				if (userVM.User.Id == id)
				{
					Role newRole = await _roleManager.FindByIdAsync(userVM.NewRole);
					await _userManager.RemoveFromRoleAsync(user, userVM.SelectedRole);
					var result = await _userManager.AddToRoleAsync(user, newRole.Name);
					if (result.Succeeded)
					{
						ViewData["result"] = "Basarili";
						return RedirectToAction("Listele");
					}
				}

				return RedirectToAction("Listele");
			}
			catch (Exception ex)
			{
				// Hata mesajını veya istisna detaylarını loglayın veya çıktı olarak görüntüleyin.
				Console.WriteLine(ex.ToString());
				return Content("Hata oluştu: " + ex.Message);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id == null || _userManager.Users == null)
			{
				return NotFound();
			}
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (user == null)
			{
				return NotFound();
			}
			return View(user);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_userManager.Users == null)
			{
				return Problem("'ContextDB.Burgerler' is null!");
			}
			var user = await _contextDb.Users.FindAsync(id);
			if (user != null)
			{
				_contextDb.Users.Remove(user);
			}
			await _contextDb.SaveChangesAsync();
			return RedirectToAction(nameof(Listele));
		}


	}
}
