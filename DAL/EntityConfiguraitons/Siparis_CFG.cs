using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Siparis_CFG : IEntityTypeConfiguration<Siparis>
	{
		public void Configure(EntityTypeBuilder<Siparis> builder)
		{
			builder.HasKey(x => x.SiparisID);
			builder.Property(x => x.Adet).HasColumnType("integer").IsRequired();
			builder.Property(x => x.ToplamFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			//siparis detay, durumu, ödeme tipği
			builder.Property(x => x.SiparisDetay).HasColumnType("nvarchar").IsRequired();
			builder.Property(x => x.SiparisDurumu).HasColumnType("nvarchar").IsRequired(true);
			builder.Property(x => x.OdemeTipi).HasColumnType("nvarchar").IsRequired();


		}
	}
}