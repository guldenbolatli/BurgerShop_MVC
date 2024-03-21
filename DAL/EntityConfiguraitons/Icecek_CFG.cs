using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Icecek_CFG : IEntityTypeConfiguration<Icecek>
	{
		public void Configure(EntityTypeBuilder<Icecek> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.ID).UseIdentityColumn(200, 1);
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			builder.Property(x => x.BirimFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.UrunFotografı).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(30);
			builder.Property(x => x.Ad).HasColumnType("nvarchar").HasMaxLength(55).IsRequired();
		}
	}
}