namespace Hamburger_MVC.Models
{
	public class Urun
	{
		public int ID { get; set; }
		public string Ad { get; set; }
		public decimal BirimFiyat { get; set; }
		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
	}
}
