namespace Hamburger_MVC.Models
{
	public class Burger_IcMalzeme
	{
		public int ID { get; set; }

		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
		public int BurgerID { get; set; }
		public int IcMalzemeID { get; set; }

		public Burger? Burger { get; set; }
		public IcMalzeme? IcMalzeme { get; set; }
	}
}
