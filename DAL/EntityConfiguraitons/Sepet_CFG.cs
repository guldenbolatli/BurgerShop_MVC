using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Sepet_CFG : IEntityTypeConfiguration<Sepet>
	{
		public void Configure(EntityTypeBuilder<Sepet> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
			builder.Property(x => x.Adet).IsRequired().HasColumnType("integer");
			builder.Property(x => x.ToplamFiyat).IsRequired().HasColumnType("decimal(18,2)");
		}
	}
}