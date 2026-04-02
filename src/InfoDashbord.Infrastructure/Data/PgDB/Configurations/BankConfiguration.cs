using InfoDashboard.Domain.Models;
using InfoDashboard.Infrastructure.Data.PgDB.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfoDashboard.Infrastructure.Data.PgDB.Configurations
{
	internal class BankConfiguration : IEntityTypeConfiguration<Bank>
	{
		public void Configure(EntityTypeBuilder<Bank> builder)
		{
			builder = builder ?? throw new ArgumentNullException(nameof(builder));

			builder.ToTable(TableConstants.Bank, t => t.ExcludeFromMigrations())
				.HasKey(bank => bank.Id);

			builder.Property(bank => bank.BankName)
				.IsRequired();
		}
	}
}
