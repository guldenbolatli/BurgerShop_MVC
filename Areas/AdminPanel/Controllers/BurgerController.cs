using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.VMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	[Authorize(Policy = "AdminOnly")]
	public class BurgerController : Controller
	{
		private readonly ContextDB _contextDB;
		public BurgerController(ContextDB contextDB)
		{
			_contextDB = contextDB;
		}

		public IActionResult Listele()
		{
			Burger_IcMalzeme_VM Burger_IcMalzeme_VM = new Burger_IcMalzeme_VM();
			Burger_IcMalzeme_VM.Burgerler = _contextDB.Burgerler.ToList();
			Burger_IcMalzeme_VM.IcMalzemeler = _contextDB.IcMalzemeler.ToList();
			return View(Burger_IcMalzeme_VM);
		}
		public IActionResult Create()
		{
			Burger_IcMalzeme_VM Burger_IcMalzeme_VM = new Burger_IcMalzeme_VM();
			return View(Burger_IcMalzeme_VM);
		}
		[HttpPost]
		public async Task<IActionResult> Create(Burger_IcMalzeme_VM _burgerVM)
		{//if (ModelState.IsValid)
		 //{
			if (_burgerVM.Burger != null)
			{
				string strDosyaAdi = _burgerVM.Burger.Fotograf.FileName;
				FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
				await _burgerVM.Burger.Fotograf.CopyToAsync(fs);
				fs.Close();
				_burgerVM.Burger.UrunFotografı = strDosyaAdi;
				_contextDB.Add(_burgerVM.Burger);
			}
			else if (_burgerVM.IcMalzeme != null)
			{
				_contextDB.Add(_burgerVM.IcMalzeme);
			}

			await _contextDB.SaveChangesAsync();
			return Content("Urun Eklendi");
			//}

		}

		public async Task<IActionResult> Update(int id)
		{
			if (id == null || _contextDB.Burgerler == null)
			{
				return NotFound();
			}
			var burger = await _contextDB.Burgerler.FindAsync(id);
			if (burger == null)
			{
				return NotFound();
			}
			return View(burger);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]//Güvenlik amaçlı kullanılıyor. Tokenlar uyuşmuyorsa olmuyor
								  //[Bind("Ad, ID, UrunFotograf, OlusturmaTarihi, BirimFiyat, VeganMi")]
		public async Task<IActionResult> Update(int id, Burger _burger)
		{
			if (id == _burger.ID)
			{
				//    return NotFound();
				//}

				//else 
				//{
				try
				{
					if (_burger.Fotograf != null)
					{
						string strDosyaAdi = _burger.Fotograf.FileName;
						FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
						await _burger.Fotograf.CopyToAsync(fs);
						fs.Close();
						_burger.UrunFotografı = strDosyaAdi;
					}
					else
					{
						_burger.UrunFotografı = _contextDB.Burgerler.Where(x => x.ID == _burger.ID).Select(x => x.UrunFotografı).FirstOrDefault();
					}
					_contextDB.Update(_burger);
					await _contextDB.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BurgerExists(_burger.ID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				//return RedirectToAction(nameof(Listele));
			}
			return RedirectToAction(nameof(Listele));
			//return View(burger);
		}

		private bool BurgerExists(int id)
		{
			return (_contextDB.Burgerler?.Any(x => x.ID == id)).GetValueOrDefault();
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id == null || _contextDB.Burgerler == null)
			{
				return NotFound();
			}
			var burger = await _contextDB.Burgerler.FirstOrDefaultAsync(x => x.ID == id);
			if (burger == null)
			{
				return NotFound();
			}
			return View(burger);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_contextDB.Burgerler == null)
			{
				return Problem("'ContextDB.Burgerler' is null!");
			}
			var burger = await _contextDB.Burgerler.FindAsync(id);
			if (burger != null)
			{
				_contextDB.Burgerler.Remove(burger);
			}
			await _contextDB.SaveChangesAsync();
			return RedirectToAction(nameof(Listele));
		}
	}
}
