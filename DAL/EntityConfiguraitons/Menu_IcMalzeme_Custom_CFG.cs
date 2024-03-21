using Hamburger_MVC.Models.Customs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Menu_IcMalzeme_Custom_CFG : IEntityTypeConfiguration<Menu_IcMalzeme_Custom>
	{
		public void Configure(EntityTypeBuilder<Menu_IcMalzeme_Custom> builder)
		{
			builder.HasKey(x => x.ID);
			builder.Property(x => x.Ad).IsRequired().HasMaxLength(55).HasColumnType("nvarchar");
		}
	}
}
