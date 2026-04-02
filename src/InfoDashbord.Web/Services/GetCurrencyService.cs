using InfoDashbord.Application.Interfaces;
using InfoDashbord.Web.ViewModels;

namespace InfoDashbord.Web.Services
{
	public class GetCurrencyService(ICurrencyService currencyService)
	{
		private readonly ICurrencyService _currencyService = currencyService ?? throw new ArgumentNullException(nameof(currencyService));

		public async Task<DashbordViewModel> GetAllCurrencies(int cityId, int bankId)
		{
			var currency = await _currencyService.GetCurrencyAsync(cityId);

			if (currency.Count > 0)
			{
				List<RateViewModel> rateList = [
				   new RateViewModel
				   {
					   Title = "USD Buy",
					   Rate = currency.Max(c=>c.USDBuyRate),
					   BestBanks = currency
					   .Where(c => c.USDBuyRate == currency.Max(x => x.USDBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
					new RateViewModel
				   {
					   Title = "USD Sell",
					   Rate = currency.Where(usd => usd.USDSaleRate > 0).Min(usd => usd.USDSaleRate),
					   BestBanks = currency
					   .Where(c => c.USDSaleRate == currency.Where(x => x.USDSaleRate > 0).Min(x => x.USDSaleRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "EUR Buy",
					   Rate = currency.Max(c=>c.EURBuyRate),
					   BestBanks = currency
					   .Where(c => c.EURBuyRate == currency.Max(x => x.EURBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "EUR Sell",
					   Rate = currency.Where(usd => usd.USDSaleRate > 0).Min(usd => usd.EURSaleRate),
					   BestBanks = currency
					   .Where(c => c.EURSaleRate == currency.Where(x => x.EURSaleRate > 0).Min(x => x.EURSaleRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "RUB Buy",
					   Rate = currency.Max(c=>c.RUBBuyRate),
					   BestBanks = currency
					   .Where(c => c.RUBBuyRate == currency.Max(x => x.RUBBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "RUB Sell",
					   Rate = currency.Where(usd => usd.RUBSaleRate > 0).Min(usd => usd.RUBSaleRate),
					   BestBanks = currency
					   .Where(c => c.RUBSaleRate == currency.Where(x => x.RUBSaleRate > 0).Min(x => x.RUBSaleRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "EURUSD Buy",
					   Rate = currency.Max(c=>c.EURUSDBuyRate),
					   BestBanks = currency
					   .Where(c => c.EURUSDBuyRate == currency.Max(x => x.EURUSDBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
					new RateViewModel
				   {
					   Title = "EURUSD Sell",
					   Rate = currency.Where(c => c.EURUSDSellRate > 0).Min(c=>c.EURUSDBuyRate),
					   BestBanks = currency
					   .Where(c => c.EURUSDSellRate == currency.Where(c => c.EURUSDSellRate > 0).Min(c=>c.EURUSDSellRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "USDRUB Buy",
					   Rate = currency.Max(c=>c.USDRUBBuyRate),
					   BestBanks = currency
					   .Where(c => c.USDRUBBuyRate == currency.Max(x => x.USDRUBBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "USDRUB Sell",
					   Rate = currency.Where(c => c.USDRUBSellRate > 0).Min(c=>c.USDRUBSellRate),
					   BestBanks = currency
					   .Where(c => c.USDRUBSellRate == currency.Where(c => c.USDRUBSellRate > 0).Min(c=>c.USDRUBSellRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "EURRUB Buy",
					   Rate = currency.Max(c=>c.EURRUBBuyRate),
					   BestBanks = currency
					   .Where(c => c.EURRUBBuyRate == currency.Max(x => x.EURRUBBuyRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				   new RateViewModel
				   {
					   Title = "EURRUB Sell",
					   Rate = currency.Where(c => c.EURRUBSellRate > 0).Min(c=>c.EURRUBSellRate),
					   BestBanks = currency
					   .Where(c => c.EURRUBSellRate == currency.Where(c => c.EURRUBSellRate > 0).Min(c=>c.EURRUBSellRate))
					   .Select(c=> new DepartmentCurrencyViewModel{
						 BankId = c.BankId,
						 BankDepartmentId = c.BankDepartmentId,
						 DepartmentName = c.DepartmentName
					   })
					   .ToList()
				   },
				];

				var ourRates = currency
					.Where(b => b.BankId == bankId)
					.Select(b => new DepartmentCurrencyViewModel
					{
						BankId = b.BankId,
						BankDepartmentId = b.BankDepartmentId,
						DepartmentName = b.DepartmentName,
						USDBuyRate = b.USDBuyRate,
						USDSaleRate = b.USDSaleRate,
						EURBuyRate = b.EURBuyRate,
						EURSaleRate = b.EURSaleRate,
						RUBBuyRate = b.RUBBuyRate,
						RUBSaleRate = b.RUBSaleRate,
						USDRUBBuyRate = b.USDRUBBuyRate,
						USDRUBSellRate = b.USDRUBSellRate,
						EURRUBBuyRate = b.EURRUBBuyRate,
						EURRUBSellRate = b.EURRUBSellRate,
						EURUSDBuyRate = b.EURUSDBuyRate,
						EURUSDSellRate = b.EURUSDSellRate
					})
					.ToList();

				DashbordViewModel model = new()
				{
					BestCurrencies = rateList,
					OurCurrency = ourRates
				};
				return model;
			}
			return new();
		}
	}
}