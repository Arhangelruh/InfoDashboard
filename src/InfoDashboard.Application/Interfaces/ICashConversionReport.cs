using InfoDashboard.Domain.Models.CashOnlineConversion;

namespace InfoDashboard.Application.Interfaces
{
	public interface ICashConversionReport
	{
		Task<List<Item>> GetConversionReport();
	}
}
