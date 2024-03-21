using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class IcMalzeme_CFG : IEntityTypeConfiguration<IcMalzeme>
	{
		public void Configure(EntityTypeBuilder<IcMalzeme> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.ID).UseIdentityColumn(300, 1);
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			builder.Property(x => x.BirimFiyat).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(x => x.Ad).HasColumnType("nvarchar").HasMaxLength(50).IsRequired();
			builder.Property(x => x.VeganMi).HasColumnType("bit").IsRequired();
		}
	}
}