using Hamburger_MVC.Models.Customs;

namespace Hamburger_MVC.Models.ViewModels
{
	public class SepetVM
	{
		public ICollection<Sepet> Sepetler { get; set; }
		public ICollection<Icecek_Custom> Icecekler { get; set; }
		public ICollection<Menu_IcMalzeme_Custom> Icmalzemeler { get; set; }
		public ICollection<Sos_Custom> Soslar { get; set; }
		public ICollection<YanUrun_Custom> YanUrunler { get; set; }
	}
}
