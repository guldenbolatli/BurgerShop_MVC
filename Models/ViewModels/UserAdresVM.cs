using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamburger_MVC.Models.ViewModels
{
	public class UserAdresVM
	{
		public User User { get; set; }
		public ICollection<Adres> Adresler { get; set; }
	}
}
