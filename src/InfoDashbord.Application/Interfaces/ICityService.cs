using InfoDashboard.Application.DTOModels;

namespace InfoDashboard.Application.Interfaces
{
	public interface ICityService
	{
		/// <summary>
		/// Get all cities.
		/// </summary>
		/// <returns>City list.</returns>
		Task<List<CityDTO>> GetAllAsync();

		/// <summary>
		/// Get city by id.
		/// </summary>
		/// <param name="id">City id</param>
		/// <returns>City dto model.</returns>
		Task<CityDTO?> GetByIdAsync(int id);
	}
}
