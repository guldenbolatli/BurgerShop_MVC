using Hamburger_MVC.Models.Enums;

namespace Hamburger_MVC.Models
{
	public class Siparis
	{
		public int SiparisID { get; set; }
		public int Adet { get; set; }
		public decimal ToplamFiyat { get; set; }
		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
		public SiparisDurumu SiparisDurumu { get; set; }
		public OdemeTipleri OdemeTipi { get; set; }
		public string SiparisDetay { get; set; }


		public int UserID { get; set; }
		public User? User { get; set; }

	}

}
