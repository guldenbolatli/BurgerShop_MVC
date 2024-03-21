using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Adres_CFG : IEntityTypeConfiguration<Adres>
	{
		public void Configure(EntityTypeBuilder<Adres> builder)
		{
			builder.HasKey(X => X.ID);
			builder.Property(x => x.Aciklama).IsRequired().HasColumnType("nvarchar").HasMaxLength(300);
			builder.Property(x => x.Baslik).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
		}
	}
}