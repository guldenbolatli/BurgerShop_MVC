using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Menu_CFG : IEntityTypeConfiguration<Menu>
	{
		public void Configure(EntityTypeBuilder<Menu> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			builder.Property(x => x.BirimFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.UrunFotografı).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(30);
			builder.Property(x => x.Ad).HasColumnType("nvarchar").HasMaxLength(55).IsRequired();
			builder.Property(x => x.SatisAdedi).HasColumnType("integer").IsRequired();
			builder.Property(x => x.Boyut).HasColumnType("nvarchar").IsRequired();
			builder.Property(x => x.ToplamKalori).HasColumnType("integer").IsRequired(false);
		}
	}
}