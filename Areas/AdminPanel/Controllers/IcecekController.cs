using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.Areas.AdminPanel.Controllers
{
	[Area("AdminPanel")]
	//[Authorize("Admin")]
	[Authorize(Policy = "AdminOnly")]
	public class IcecekController : Controller
	{
		private readonly ContextDB _contextDB;
		public IcecekController(ContextDB contextDB)
		{
			_contextDB = contextDB;
		}
		public IActionResult Listele()
		{
			return View(_contextDB.Icecekler.ToList());
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(Icecek _icecek)
		{
			string strDosyaAdi = _icecek.Fotograf.FileName;
			FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
			await _icecek.Fotograf.CopyToAsync(fs);
			fs.Close();
			_icecek.UrunFotografı = strDosyaAdi;

			_contextDB.Add(_icecek);
			await _contextDB.SaveChangesAsync();
			return Content("Urun eklendi!!");
		}
		public async Task<IActionResult> Update(int id)
		{
			if (id == null || _contextDB.Icecekler == null)
			{
				return NotFound();
			}
			var icecek = await _contextDB.Icecekler.FindAsync(id);
			if (icecek == null)
			{
				return NotFound();
			}
			return View(icecek);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, Icecek _icecek)
		{
			if (id == _icecek.ID)
			{
				try
				{
					if (_icecek.Fotograf != null)
					{
						string strDosyaAdi = _icecek.Fotograf.FileName;
						FileStream fs = new FileStream("wwwroot/Admin/urunfoto/" + strDosyaAdi, FileMode.Create);
						await _icecek.Fotograf.CopyToAsync(fs);
						fs.Close();
						_icecek.UrunFotografı = strDosyaAdi;
					}
					else
					{
						_icecek.UrunFotografı = _contextDB.Icecekler.Where(x => x.ID == _icecek.ID).Select(x => x.UrunFotografı).FirstOrDefault();
					}
					_contextDB.Update(_icecek);
					await _contextDB.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!IcecekExists(_icecek.ID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
			}
			return RedirectToAction(nameof(Listele));
		}

		private bool IcecekExists(int id)
		{
			return (_contextDB.Icecekler?.Any(x => x.ID == id)).GetValueOrDefault();
		}

		public async Task<IActionResult> Delete(int id)
		{
			if (id == null || _contextDB.Icecekler == null)
				return NotFound();
			var icecek = await _contextDB.Icecekler.FirstOrDefaultAsync(x => x.ID == id);
			if (icecek == null)
			{
				return NotFound();
			}
			return View(icecek);
		}
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_contextDB.Icecekler == null)
			{
				return Problem("'ContextDB.Icecekler' is null!");
			}
			var icecek = await _contextDB.Icecekler.FindAsync(id);
			if (icecek != null)
			{
				_contextDB.Icecekler.Remove(icecek);
			}
			await _contextDB.SaveChangesAsync();
			return RedirectToAction(nameof(Listele));
		}
	}
}
