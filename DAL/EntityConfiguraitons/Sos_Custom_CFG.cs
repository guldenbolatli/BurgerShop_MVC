using Hamburger_MVC.Models.Customs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Sos_Custom_CFG : IEntityTypeConfiguration<Sos_Custom>
	{
		public void Configure(EntityTypeBuilder<Sos_Custom> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.Ad).IsRequired().HasMaxLength(55).HasColumnType("nvarchar");
			builder.Property(x => x.BirimFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.ToplamFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.Adet).HasColumnType("integer").IsRequired();
		}
	}
}
