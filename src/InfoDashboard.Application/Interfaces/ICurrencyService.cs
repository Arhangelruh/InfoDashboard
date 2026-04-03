using InfoDashboard.Application.DTOModels;

namespace InfoDashboard.Application.Interfaces
{
	public interface ICurrencyService
	{
		/// <summary>
		/// Get currency.
		/// </summary>
		/// <returns></returns>
		Task<List<CurrencyDTO>> GetCurrencyAsync(int cityId);
	}
}
