using InfoDashboard.Infrastructure.Data.PgDB.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InfoDashboard.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoDashboard.Infrastructure.Data.PgDB.Configurations
{
	internal class CityConfiguration : IEntityTypeConfiguration<City>
	{
		public void Configure(EntityTypeBuilder<City> builder)
		{
			builder = builder ?? throw new ArgumentNullException(nameof(builder));

			builder.ToTable(TableConstants.City, t => t.ExcludeFromMigrations())
				.HasKey(city => city.Id);

			builder.Property(city => city.CityName)
				.IsRequired();

			builder.Property(city => city.CityURL);
		}
	}
}
