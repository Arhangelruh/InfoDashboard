using InfoDashboard.Application.Interfaces;
using InfoDashboard.Infrastructure.Data.PgDB.Context;
using InfoDashboard.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDashboard.Infrastructure
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

			services.AddDbContextFactory<GreatCurrencyContext>(options =>
			  options.UseNpgsql(connectionString));

			services.AddScoped<ICityService, CityService>();
			services.AddScoped<IBankService, BankService>();
			services.AddScoped<ICurrencyService, CurrencyService>();

			return services;
		}
	}
}

