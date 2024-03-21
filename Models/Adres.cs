namespace Hamburger_MVC.Models
{
	public class Adres
	{
		public int ID { get; set; }
		public string Baslik { get; set; }
		public string Aciklama { get; set; }
		public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
		public int UserID { get; set; }
		public User User { get; set; } 
	}
}
