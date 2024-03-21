using Hamburger_MVC.DAL.EntityConfiguraitons;
using Hamburger_MVC.Models;
using Hamburger_MVC.Models.Customs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hamburger_MVC.DAL
{
	public class ContextDB : IdentityDbContext<User,Role,int>
	{
		public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

		public DbSet<Adres> Adresler { get; set; }
		public DbSet<Burger> Burgerler { get; set; }
		public DbSet<Burger_IcMalzeme> Burger_IcMalzemeler { get; set; }
		public DbSet<Sepet> Sepetler { get; set; }
		public DbSet<Icecek> Icecekler { get; set; }
		public DbSet<IcMalzeme> IcMalzemeler { get; set; }
		public DbSet<Menu> Menuler { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Siparis> Siparisler { get; set; }
		public DbSet<Sos> Soslar { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<YanUrun> YanUrunler { get; set; }
		public DbSet<Icecek_Custom>	 Icecek_Customs{ get; set; }
		public DbSet<Menu_IcMalzeme_Custom> Menu_IcMalzeme_Customs { get; set; }
		public DbSet<Sos_Custom> Sos_Customs { get; set; }
		public DbSet<YanUrun_Custom> YanUrun_Customs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration<Adres>(new Adres_CFG());
			modelBuilder.ApplyConfiguration<Burger>(new Burger_CFG());
			modelBuilder.ApplyConfiguration<Burger_IcMalzeme>(new Burger_IcMalzeme_CFG());
			modelBuilder.ApplyConfiguration<Sepet>(new Sepet_CFG());
			modelBuilder.ApplyConfiguration<Icecek>(new Icecek_CFG());
			modelBuilder.ApplyConfiguration<IcMalzeme>(new IcMalzeme_CFG());
			modelBuilder.ApplyConfiguration<Menu>(new Menu_CFG());
			modelBuilder.ApplyConfiguration<Role>(new Role_CFG());
			modelBuilder.ApplyConfiguration<Siparis>(new Siparis_CFG());
			modelBuilder.ApplyConfiguration<Sos>(new Sos_CFG());
			modelBuilder.ApplyConfiguration<User>(new User_CFG());
			modelBuilder.ApplyConfiguration<YanUrun>(new YanUrun_CFG());
			modelBuilder.ApplyConfiguration<Icecek_Custom>(new Icecek_Custom_CFG());
			modelBuilder.ApplyConfiguration<Menu_IcMalzeme_Custom>(new Menu_IcMalzeme_Custom_CFG());
			modelBuilder.ApplyConfiguration<Sos_Custom>(new Sos_Custom_CFG());
			modelBuilder.ApplyConfiguration<YanUrun_Custom>(new YanUrun_Custom_CFG());
			base.OnModelCreating(modelBuilder);
		}

	}
}
