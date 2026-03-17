using InfoDashbord.Application.Interfaces;
using InfoDashbord.Infrastructure.Data.PgDB.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDashbord.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
		{
			var connectionString =
				configuration.GetConnectionString("GreatCurrencyDatabase")
				?? Environment.GetEnvironmentVariable("GreatCurrencyDatabase");

			if (string.IsNullOrWhiteSpace(connectionString))
				throw new InvalidOperationException("Connection string is not configured.");

			services.AddDbContext<GreatCurrencyContext>(options =>
				options.UseNpgsql(connectionString));

			services.AddScoped<IGreatCurrencyDbContext>(sp =>
				sp.GetRequiredService<GreatCurrencyContext>());

			return services;
		}
	}
}

