namespace Hamburger_MVC.Models.ViewModels
{
    public class UrunlerVM
    {
        public ICollection<Menu>? Menuler { get; set; }
        public ICollection<Sos>? Soslar { get; set; }
        public ICollection<YanUrun>? YanUrunler { get; set; }
        public ICollection<Icecek>? Icecekler { get; set; }
        public ICollection<IcMalzeme>? IcMalzemeler { get; set; }
    }
}
