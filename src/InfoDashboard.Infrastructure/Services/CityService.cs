using InfoDashboard.Application.DTOModels;
using InfoDashboard.Application.Interfaces;
using InfoDashboard.Infrastructure.Data.PgDB.Context;
using Microsoft.EntityFrameworkCore;

namespace InfoDashboard.Infrastructure.Services
{
	/// <inheritdoc/>		
	public class CityService(IDbContextFactory<GreatCurrencyContext> factory) : ICityService
	{
		private readonly IDbContextFactory<GreatCurrencyContext> _factory = factory ?? throw new ArgumentNullException(nameof(factory));


		public async Task<List<CityDTO>> GetAllAsync()
		{
			var db = await _factory.CreateDbContextAsync();

			var allCities = await db.Cities
				.AsNoTracking()
				.Select(c => new CityDTO
				{
					Id = c.Id,
					CityName = c.CityName					
				})
				.ToListAsync();

			return allCities;
		}

		public async Task<CityDTO?> GetByIdAsync(int id) {
			var db = await _factory.CreateDbContextAsync();
			var city = await db.Cities
				.AsNoTracking ()
				.Where(c => c.Id == id)
				.Select(c => new CityDTO
				{
					Id = c.Id,
					CityName= c.CityName					
				})
				.FirstOrDefaultAsync();

			return city;
		}
	}
}
