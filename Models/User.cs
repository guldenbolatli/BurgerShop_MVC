using Hamburger_MVC.Models.Customs;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamburger_MVC.Models
{
	public class User:IdentityUser<int>
	{
		public string Ad { get; set; }
		public string Soyad { get; set; }
		[NotMapped]
		public string AdSoyad { get => Ad + Soyad; }
		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

		public ICollection<Sepet>? Sepetler { get; set; }
		public ICollection<Siparis>? Siparisler { get; set; }

		public ICollection<Menu_IcMalzeme_Custom>? MenuIcMalzemeCustom { get; set; }
		public ICollection<Sos_Custom>? Sos_Customs { get; set; }
		public ICollection<YanUrun_Custom>? YanUrun_Customs { get; set; }
		public ICollection<Icecek_Custom>? Icecek_Customs { get; set; }

		public ICollection<Adres>? Adresler { get; set; }
	}
}
