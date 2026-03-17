using InfoDashbord.Domain.Models;
using InfoDashbord.Infrastructure.Data.PgDB.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoDashbord.Infrastructure.Data.PgDB.Configurations
{
	internal class RequestConfiguration : IEntityTypeConfiguration<Request>
	{
		public void Configure(EntityTypeBuilder<Request> builder)
		{
			builder = builder ?? throw new ArgumentNullException(nameof(builder));

			builder.ToTable(TableConstants.Request, t => t.ExcludeFromMigrations())
				.HasKey(request => request.Id);

			builder.Property(request => request.IncomingDate)
				.HasColumnType("Timestamp");
		}
	}
}
