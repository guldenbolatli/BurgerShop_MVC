using Hamburger_MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hamburger_MVC.DAL.EntityConfiguraitons
{
	public class Role_CFG : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			builder.HasData(
				new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
				new Role { Id = 2, Name = "Uye", NormalizedName = "UYE" }
				);
		}
	}
}