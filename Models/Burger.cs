using System.ComponentModel.DataAnnotations.Schema;

namespace Hamburger_MVC.Models
{
	public class Burger:Urun
	{
		public bool VeganMi { get; set; }
		public string? UrunFotografı { get; set; }
		[NotMapped]
		public IFormFile? Fotograf { get; set; }
		public ICollection<Burger_IcMalzeme>? BurgerinIcMalzemeleri { get; set; }

		public Menu? Menu { get; set; }
	}
}
