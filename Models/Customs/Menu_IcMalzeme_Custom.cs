using Hamburger_MVC.Models.Interfaces;

namespace Hamburger_MVC.Models.Customs
{
	public class Menu_IcMalzeme_Custom:ISilinebilir
	{
		public int ID { get; set; }
		public string Ad { get; set; }

		public int UserID { get; set; }
		public User? User { get; set; }
		public int MenuID { get; set; }
		public Menu Menu { get; set; }
	
		public int? SepetID { get; set; }
		public Sepet? Sepet { get; set; }

		public int? IcMalzemeID { get; set; }
		public IcMalzeme? IcMalzeme { get; set; }

	}
}
