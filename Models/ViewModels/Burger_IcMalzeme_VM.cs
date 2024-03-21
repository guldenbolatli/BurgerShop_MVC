namespace Hamburger_MVC.Models.VMs
{
    public class Burger_IcMalzeme_VM
    {
        public Burger? Burger { get; set; }
        public ICollection<Burger>? Burgerler { get; set; }
        public IcMalzeme? IcMalzeme { get; set; }
        public ICollection<IcMalzeme>? IcMalzemeler { get; set; }
    }
}
