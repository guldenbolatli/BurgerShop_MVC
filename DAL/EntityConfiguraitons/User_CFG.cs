using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class User_CFG : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property(x => x.OlusturmaTarihi).HasColumnType("datetime").IsRequired();
		}
	}
}