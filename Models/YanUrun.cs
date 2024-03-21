using Hamburger_MVC.Models.Customs;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamburger_MVC.Models
{
	public class YanUrun:Urun
	{
		public bool VeganMi { get; set; }
		public string UrunFotografı { get; set; }
		[NotMapped]
		public IFormFile? Fotograf { get; set; }



		public ICollection<YanUrun_Custom>? YanUrun_Customs { get; set; }
	}
}
