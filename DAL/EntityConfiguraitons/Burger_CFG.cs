using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Burger_CFG : IEntityTypeConfiguration<Burger>
	{
		public void Configure(EntityTypeBuilder<Burger> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.ID).UseIdentityColumn(100, 1);
			builder.Property(x => x.UrunFotografı).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(30);
			builder.Property(x => x.VeganMi).HasColumnType("bit").IsRequired();
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			builder.Property(x => x.BirimFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.Ad).HasColumnType("nvarchar").HasMaxLength(55).IsRequired();
		}
	}
}