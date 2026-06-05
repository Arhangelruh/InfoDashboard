using InfoDashboard.Application.Interfaces;
using InfoDashboard.Application.Services;
using InfoDashboard.Infrastructure.Data.Departments;
using InfoDashboard.Infrastructure.Data.PgDB.Context;
using InfoDashboard.Infrastructure.Data.ReportDB.Context;
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

			var reportingConnectionString =
				configuration.GetConnectionString("ReportingDatabase")
				?? Environment.GetEnvironmentVariable("ReportingDatabase");

			if (string.IsNullOrWhiteSpace(reportingConnectionString))
				throw new InvalidOperationException("Connection string to ReportDB is not configured.");

			services.AddDbContextFactory<ReportingDbContext>(options =>
			       options.UseSqlServer(reportingConnectionString));

			services.AddScoped<ICityService, CityService>();
			services.AddScoped<IBankService, BankService>();
			services.AddScoped<ICurrencyService, CurrencyService>();
			services.AddScoped<IGetExchangeReportInfo, GetExchangeReportInfo>();
			services.AddScoped<ICashReport, CashReport>();
			services.AddScoped<IGetDepartments, GetDepartments>();
			services.AddScoped<IGetConversionReport, GetConversionReport>();
			services.AddScoped<ICashConversionReport, CashConversionReport>();

			return services; 
		}
	}
}

