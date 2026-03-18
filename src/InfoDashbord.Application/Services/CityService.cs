using InfoDashbord.Application.DTOModels;
using InfoDashbord.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Application.Services
{
	/// <inheritdoc/>		
	public class CityService(IGreatCurrencyDbContext db) : ICityService
	{
		private readonly IGreatCurrencyDbContext _db = db ?? throw new ArgumentNullException(nameof(db));


		public async Task<List<CityDTO>> GetAllAsync()
		{
			var allCities = await _db.Cities
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
		    
			var city = await _db.Cities
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
