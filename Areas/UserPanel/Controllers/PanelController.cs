using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.UserPanel.Controllers
{
	[Area("UserPanel")]
	
	public class PanelController : Controller
	{
		private readonly ContextDB _contextDb;
		UrunlerVM urunlerVM;
		UserManager<User> _userManager;
		public PanelController(ContextDB context, UserManager<User> userManager)
		{
			_contextDb = context;
			urunlerVM = new UrunlerVM()
			{
				Menuler = _contextDb.Menuler.Include(x => x.Burger).ThenInclude(x => x.BurgerinIcMalzemeleri).ThenInclude(x => x.IcMalzeme).Include(x => x.Icecek).ToList(),
				Icecekler = _contextDb.Icecekler.ToList(),
				Soslar = _contextDb.Soslar.ToList(),
				YanUrunler = _contextDb.YanUrunler.ToList(),
				IcMalzemeler = _contextDb.IcMalzemeler.ToList()
			};
			_userManager = userManager;
		}
		public async Task<IActionResult> Index()
		{
			User user = await _userManager.GetUserAsync(User);
			if (user != null)
			{
				var sepetler = await _contextDb.Sepetler.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Menu).ToListAsync();
				ViewData["sepet"] = sepetler;
			}
			
			return View(urunlerVM);
		}
        public async Task<IActionResult> Deneme()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var sepetler = await _contextDb.Sepetler.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Menu).ToListAsync();
                ViewData["sepet"] = sepetler;
            }

            return View(urunlerVM);
        }


    }
}
