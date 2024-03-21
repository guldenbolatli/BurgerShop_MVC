using Hamburger_MVC.DAL;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.Customs;
using Hamburger_MVC.Models.Enums;
using Hamburger_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hamburger_MVC.Areas.UserPanel.Controllers
{
	[Area("UserPanel")]
	public class SepetController : Controller
	{
		private readonly ContextDB _contextDB;
		private readonly UserManager<User> _userManager;
		Menu_IcMalzeme_Custom kullaniciIcMalzeme;
		Sos_Custom kullanciSoslar;
		YanUrun_Custom kullaniciYanUrun;


		public SepetController(ContextDB contextDB, UserManager<User> userManager)
		{
			_contextDB = contextDB;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{

			return View();
		}
		public async Task<IActionResult> Ekle(int MenuID, string MenuAdi, int Icecek, int[] YanUrun, int[] Sos, int[] IcMalzemeler, int Adet)
		{
			List<YanUrun> yanUrunler = new List<YanUrun>();
			List<Sos> soslar = new List<Sos>();
			List<IcMalzeme> istenenIcMalzemeler = new List<IcMalzeme>();
			User user = await _userManager.GetUserAsync(User);

			Menu secilenMenu = _contextDB.Menuler.FirstOrDefault(x => x.ID.Equals(MenuID));
			decimal toplamFiyat = secilenMenu.BirimFiyat * Adet;
			Sepet sepet = new Sepet()
			{
				MenuID = MenuID,
				UserID = user.Id,
				Adet = Adet,
			};
			_contextDB.Sepetler.Add(sepet);
			_contextDB.SaveChanges();
			Icecek secilenIcecek = await _contextDB.Icecekler.FirstOrDefaultAsync(x => x.ID == Icecek);
			Icecek_Custom kullaniciIcecek = new Icecek_Custom()
			{
				Ad = secilenIcecek.Ad,
				UserID = user.Id,
				SepetID = sepet.ID,
				IcecekID = secilenIcecek.ID,
				BirimFiyat = secilenIcecek.BirimFiyat,
				Adet = Adet,
				ToplamFiyat = secilenIcecek.BirimFiyat,
			};
			_contextDB.Icecek_Customs.Add(kullaniciIcecek);
			foreach (int yanUrunID in YanUrun)
			{
				yanUrunler.Add(await _contextDB.YanUrunler.FirstOrDefaultAsync(x => x.ID.Equals(yanUrunID)));
			}
			foreach (int icMalzemeId in IcMalzemeler)
			{
				istenenIcMalzemeler.Add(await _contextDB.IcMalzemeler.FirstOrDefaultAsync(x => x.ID.Equals(icMalzemeId)));
			}
			foreach (int sosId in Sos)
			{
				soslar.Add(await _contextDB.Soslar.FirstOrDefaultAsync(x => x.ID.Equals(sosId)));
			}
			foreach (var item in istenenIcMalzemeler)
			{
				kullaniciIcMalzeme = new Menu_IcMalzeme_Custom()
				{
					Ad = item.Ad,
					UserID = user.Id,
					MenuID = MenuID,
					SepetID = sepet.ID,
					IcMalzemeID = item.ID
				};
				_contextDB.Menu_IcMalzeme_Customs.Add(kullaniciIcMalzeme);
			}
			foreach (var item in soslar)
			{
				kullanciSoslar = new Sos_Custom()
				{
					Ad = item.Ad,
					UserID = user.Id,
					SepetID = sepet.ID,
					SosID = item.ID,
					Adet = Adet,
					BirimFiyat = _contextDB.Soslar.FirstOrDefault(x => x.ID.Equals(item.ID)).BirimFiyat,

				};
				kullanciSoslar.ToplamFiyat = kullanciSoslar.Adet * kullanciSoslar.BirimFiyat;
				toplamFiyat += kullanciSoslar.ToplamFiyat;
				_contextDB.Sos_Customs.Add(kullanciSoslar);
			}
			foreach (var item in yanUrunler)
			{
				kullaniciYanUrun = new YanUrun_Custom()
				{
					Ad = item.Ad,
					UserID = user.Id,
					SepetID = sepet.ID,
					YanUrunId = item.ID,
					Adet = Adet,
					BirimFiyat = _contextDB.YanUrunler.FirstOrDefault(x => x.ID.Equals(item.ID)).BirimFiyat,

				};
				kullaniciYanUrun.ToplamFiyat = kullaniciYanUrun.Adet * kullaniciYanUrun.BirimFiyat;
				toplamFiyat += kullaniciYanUrun.ToplamFiyat;
				_contextDB.YanUrun_Customs.Add(kullaniciYanUrun);
			}

			sepet.ToplamFiyat = toplamFiyat;

			_contextDB.SaveChanges();
			return View();
		}


		public async Task<IActionResult> SepetGoster()
		{
			User user = await _userManager.GetUserAsync(User);
			SepetVM sepetVm = new SepetVM()
			{
				Sepetler = _contextDB.Sepetler.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Menu).ToList(),
				Icecekler = _contextDB.Icecek_Customs.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Icecek).ToList(),
				Soslar = _contextDB.Sos_Customs.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Sos).ToList(),
				Icmalzemeler = _contextDB.Menu_IcMalzeme_Customs.Where(x => x.UserID.Equals(user.Id)).Include(x => x.IcMalzeme).ToList(),
				YanUrunler = _contextDB.YanUrun_Customs.Where(x => x.UserID.Equals(user.Id)).Include(x => x.YanUrun).ToList()
			};

			return View(sepetVm);
		}

		public async Task<IActionResult> Sil(int sepetId)
		{
			Sepet sepet = await _contextDB.Sepetler.FirstOrDefaultAsync(x => x.ID.Equals(sepetId));
			var menu_IcMalzeme_Custom = _contextDB.Menu_IcMalzeme_Customs.Where(x => x.SepetID.Equals(sepetId)).ToList();
			var icecekCustom = _contextDB.Icecek_Customs.Where(x => x.SepetID.Equals(sepetId)).ToList();
			var yanUrunCustom = _contextDB.YanUrun_Customs.Where(x => x.SepetID.Equals(sepetId)).ToList();
			var sosCustom = _contextDB.Sos_Customs.Where(x => x.SepetID.Equals(sepetId)).ToList();
			foreach (var item in menu_IcMalzeme_Custom)
			{
				_contextDB.Menu_IcMalzeme_Customs.Remove(item);
			}
			foreach (var item in icecekCustom)
			{
				_contextDB.Icecek_Customs.Remove(item);
			}
			foreach (var item in yanUrunCustom)
			{
				_contextDB.YanUrun_Customs.Remove(item);
			}
			foreach (var item in sosCustom)
			{
				_contextDB.Sos_Customs.Remove(item);
			}

			_contextDB.Sepetler.Remove(sepet);
			_contextDB.SaveChangesAsync();
			return RedirectToAction("SepetGoster");
		}
		[Authorize]
		public async Task<IActionResult> SepetOnayla(List<int> sepetId)
		{
			User user = await _userManager.GetUserAsync(User);
			var odemeTipleri = Enum.GetValues(typeof(OdemeTipleri)).Cast<OdemeTipleri>();

			var odemeTipleriList = odemeTipleri.Select(ot => new SelectListItem
			{
				Text = Enum.GetName(typeof(OdemeTipleri), ot),
				Value = ((int)ot).ToString(),
			}).ToList();

			SepetOnaylaVM sepetOnaylaVM = new SepetOnaylaVM()
			{
				Sepetler = _contextDB.Sepetler.Where(x => x.UserID.Equals(user.Id)).Include(x => x.Menu).ToList(),
				Kullanici = user,
				Adresler = _contextDB.Adresler.Where(x => x.UserID.Equals(user.Id)).ToList(),
				OdemeTipleri = odemeTipleriList
			};


			return View(sepetOnaylaVM);
		}
		[Authorize]
		public async Task<IActionResult> SiparisOlustur(SepetOnaylaVM sepetOnaylaVM)
		{
			//User user = await _userManager.GetUserAsync(User);
			//var sepetListe = _contextDB.Sepetler.Where(x => x.UserID.Equals(sepetOnaylaVM.Kullanici.Id)).Include(x => x.Menu)
			//	//.Include(x => x.YanUrun_Customs).ThenInclude(x => x.YanUrun).Include(x => x.MenuIcMalzemeCustom).ThenInclude(x => x.IcMalzeme).Include(x => x.Sos_Customs).ThenInclude(x => x.Sos).Include(x => x.Icecek_Customs).ThenInclude(x => x.Icecek)
			//	.ToList();

			//foreach (var item in sepetListe)
			//{
			//	var siparisDetay = new
			//	{
			//		Id = item.ID,
			//		UrunAdi = item.Menu.Ad,
			//		Fiyat = item.ToplamFiyat,
			//		Adet = item.Adet,
			//		Icecek = _contextDB.Icecek_Customs.FirstOrDefault(x => x.SepetID == item.ID && x.UserID == user.Id).Ad,
			//	};

			//	string sepetDetayJson = JsonConvert.SerializeObject(siparisDetay);


			//}


			return View();


		}


	}
}
