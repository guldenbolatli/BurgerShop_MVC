using Hamburger_MVC.Models.Customs;

namespace Hamburger_MVC.Models
{
	public class IcMalzeme:Urun
	{
		public bool VeganMi { get; set; }

		public ICollection<Burger_IcMalzeme>? IcMalzemeninBurgerleri { get; set; }
		public ICollection<Menu_IcMalzeme_Custom>? MenuIcMalzemeCustom { get; set; }
	}
}
