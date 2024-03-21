using System.ComponentModel;

namespace Hamburger_MVC.Models.Enums
{
	public enum OdemeTipleri
	{
		[Description("Nakit Ödeme")]
		Nakit,

		[Description("Online Ödeme")]
		Online,

		[Description("Kapıda Kredi Kartı")]
		KapidaKrediKarti
	}
}
