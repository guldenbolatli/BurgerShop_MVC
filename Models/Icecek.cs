using Hamburger_MVC.Models.Customs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamburger_MVC.Models
{
	public class Icecek:Urun
	{
		public string UrunFotografı { get; set; }
		[NotMapped]
		public IFormFile? Fotograf { get; set; }
		public ICollection<Menu>? MenudekiIcecek { get; set; }

		public ICollection<Icecek_Custom>? Icecek_Customs { get; set; }
	}
}
