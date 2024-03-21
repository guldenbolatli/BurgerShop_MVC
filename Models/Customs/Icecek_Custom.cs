using Hamburger_MVC.Models.Interfaces;

namespace Hamburger_MVC.Models.Customs
{
	public class Icecek_Custom:ISilinebilir
	{
		public int ID { get; set; }
		public string Ad { get; set; }
		public decimal BirimFiyat { get; set; }
		public int Adet { get; set; }
		public decimal ToplamFiyat { get; set; }

		public int UserID { get; set; }
		public User User { get; set; }


		public int? SepetID { get; set; }
		public Sepet? Sepet { get; set; }

		public int? IcecekID { get; set; }
		public Icecek? Icecek { get; set; }
	}

}
