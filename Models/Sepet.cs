using Hamburger_MVC.Models.Customs;
using Hamburger_MVC.Models.Interfaces;

namespace Hamburger_MVC.Models
{
	public class Sepet:ISilinebilir
	{
		public int ID { get; set; }
		public int Adet { get; set; }
		public decimal ToplamFiyat { get; set; }
		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

		public int UserID { get; set; }
		public User? User { get; set; }
		public int MenuID { get; set; }
		public Menu? Menu { get; set; }


		public ICollection<Menu_IcMalzeme_Custom>? MenuIcMalzemeCustom { get; set; }
		public ICollection<Sos_Custom>? Sos_Customs { get; set; }
		public ICollection<YanUrun_Custom>? YanUrun_Customs { get; set; }

		public ICollection<Icecek_Custom>? Icecek_Customs { get; set; }
	}
}
