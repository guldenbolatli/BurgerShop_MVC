using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Burger_IcMalzeme_CFG : IEntityTypeConfiguration<Burger_IcMalzeme>
	{
		public void Configure(EntityTypeBuilder<Burger_IcMalzeme> builder)
		{
			builder.HasKey(x => x.ID);
		}
	}
}