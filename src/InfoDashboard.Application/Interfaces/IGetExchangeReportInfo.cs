namespace InfoDashboard.Application.Interfaces
{
	public interface IGetExchangeReportInfo
	{
		/// <summary>
		/// Get report from database.
		/// </summary>
		/// <returns></returns>
		Task<string?> GetReport();
	}
}
