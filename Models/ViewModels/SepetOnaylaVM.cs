using Hamburger_MVC.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hamburger_MVC.Models.ViewModels
{
    public class SepetOnaylaVM
    {
        public ICollection<Sepet> Sepetler { get; set; }
        public User Kullanici { get; set; }
        public ICollection<Adres> Adresler { get; set; }
        public ICollection<SelectListItem> OdemeTipleri { get; set; }
    }
}
