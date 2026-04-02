using InfoDashbord.Application.DTOModels;
using InfoDashbord.Application.Interfaces;
using InfoDashbord.Infrastructure.Data.PgDB.Context;
using Microsoft.EntityFrameworkCore;

namespace InfoDashbord.Infrastructure.Services
{
	public class CurrencyService(IDbContextFactory<GreatCurrencyContext> factory) : ICurrencyService
	{
		private readonly IDbContextFactory<GreatCurrencyContext> _factory = factory ?? throw new ArgumentNullException(nameof(factory));
	
		public async Task<List<CurrencyDTO>> GetCurrencyAsync(int cityId)
		{
			var db = await _factory.CreateDbContextAsync();

			var currency = await db.Currencies
			.Where(c => c.RequestId ==
					db.Requests
					  .Where(r => r.IsCompleted &&
							 r.Currencies.Any(cu => cu.BankDepartment.CityId == cityId))
					  .OrderByDescending(r => r.Id)
					  .Select(r => r.Id)
					  .FirstOrDefault())
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
					  DepartmentName = c.BankDepartment.DepartmentName,
					  DepartmentAddress = c.BankDepartment.DepartmentAddress,
					  BankId = c.BankDepartment.BankId
				  })
			.ToListAsync();

			return currency;
		}
	}
}
