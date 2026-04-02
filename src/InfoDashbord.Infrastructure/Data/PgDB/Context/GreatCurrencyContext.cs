using InfoDashbord.Domain.Models;
using InfoDashbord.Infrastructure.Data.PgDB.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Infrastructure.Data.PgDB.Context
{
	public class GreatCurrencyContext(DbContextOptions<GreatCurrencyContext> options) : DbContext(options)
	{

		/// <summary>
		/// City.
		/// </summary>
		public DbSet<City> Cities { get; set; }

		/// <summary>
		/// Banks.
		/// </summary>
		public DbSet<Bank> Banks { get; set; }

		/// <summary>
		/// Bank departments.
		/// </summary>
		public DbSet<BankDepartment> BankDepartments { get; set; }

		/// <summary>
		/// Request.
		/// </summary>
		public DbSet<Request> Requests { get; set; }

		/// <summary>
		/// Currencies.
		/// </summary>
		public DbSet<Currency> Currencies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder = modelBuilder ?? throw new ArgumentNullException(nameof(modelBuilder));

			modelBuilder.ApplyConfiguration(new CityConfiguration());
			modelBuilder.ApplyConfiguration(new BankConfiguration());
			modelBuilder.ApplyConfiguration(new RequestConfiguration());
			modelBuilder.ApplyConfiguration(new BankDepartmentConfiguration());
			modelBuilder.ApplyConfiguration(new CurrencyConfiguration());

			base.OnModelCreating(modelBuilder);
		}
	}
}
