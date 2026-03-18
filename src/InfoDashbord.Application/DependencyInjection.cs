using InfoDashbord.Application.Interfaces;
using InfoDashbord.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfoDashbord.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{

			services.AddScoped<ICityService, CityService>();
			services.AddScoped<IBankService, BankService>();
			services.AddScoped<ICurrencyService, CurrencyService>();

			return services;
		}
	}
}
