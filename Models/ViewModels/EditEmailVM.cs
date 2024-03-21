using System.ComponentModel.DataAnnotations;

namespace Hamburger_MVC.Models.ViewModels
{
    public class EditEmailVM
    {
        [Required]
        [EmailAddress]
        public string CurrentEmail { get; set; }

        [Required]
        [EmailAddress]
        public string NewEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
