using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamburger_MVC.Models.ViewModels
{
	public class UserVM
	{
		public User User  { get; set; }
		public string SelectedRole { get; set; }
		public string? NewRole { get; set; }
		public SelectList Roles { get; set; }
	}
}
