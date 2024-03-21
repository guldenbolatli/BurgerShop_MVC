using Hamburger_MVC.Models.Customs;
using Hamburger_MVC.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hamburger_MVC.Models
{
	public class Menu:Urun
	{
		public int? ToplamKalori { get; set; }
		public int SatisAdedi { get; set; }
		public Boyut Boyut { get; set; }
		public string UrunFotografı { get; set; }
		[NotMapped]
		public IFormFile? Fotograf { get; set; }


		//İlişkiker

		public int BurgerID { get; set; }
		public Burger? Burger { get; set; }

		public int IcecekID { get; set; }
		public Icecek? Icecek { get; set; }


		public ICollection<Sepet>? Sepetler { get; set; }
		public ICollection<Menu_IcMalzeme_Custom>? MenuIcMalzemeCustom { get; set; }

	}
}
