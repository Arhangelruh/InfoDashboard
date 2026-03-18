using InfoDashbord.Application.DTOModels;
using InfoDashbord.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Application.Services
{
	public class CurrencyService(IGreatCurrencyDbContext db) : ICurrencyService
	{
		private readonly IGreatCurrencyDbContext _db = db ?? throw new ArgumentNullException(nameof(db));
	
		public async Task<List<CurrencyDTO>> GetCurrencyAsync(int cityId)
		{		
			var currency = await _db.Currencies
			.Where(c => c.RequestId ==
				    _db.Requests
			          .Where(r => r.IsCompleted &&
							 r.Currencies.Any(cu => cu.BankDepartment.CityId == cityId))
					  .OrderByDescending(r => r.Id)
					  .Select(r => r.Id)
					  .FirstOrDefault()
					&& c.BankDepartment.CityId == cityId)
	        .Select(c => new CurrencyDTO
			{
				USDBuyRate = c.USDBuyRate,
				USDSaleRate = c.USDSaleRate,
				EURBuyRate = c.EURBuyRate,
				EURSaleRate = c.EURSaleRate,
				RUBBuyRate = c.RUBBuyRate,
				RUBSaleRate = c.RUBSaleRate,
				EURUSDBuyRate = c.EURUSDBuyRate,
				EURUSDSellRate = c.EURUSDSellRate,
				USDRUBBuyRate = c.USDRUBBuyRate,
				USDRUBSellRate = c.USDRUBSellRate,
				EURRUBBuyRate = c.EURRUBBuyRate,
				EURRUBSellRate = c.EURRUBSellRate,
				BankDepartmentId = c.BankDepartmentId,
				DepartmentName = c.BankDepartment.DepartmentAddress
	        })
			.ToListAsync();

			return currency;
		}
	}
}
